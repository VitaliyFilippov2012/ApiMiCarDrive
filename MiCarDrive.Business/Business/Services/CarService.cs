using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.AutoMapper;
using Business.Interfaces;
using DBContext.Context;
using DBContext.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Filters;
using Shared.Models;
using Car = Shared.Models.Car;
using Type = Shared.Models.Type;

namespace Business.Services
{
    public class CarService : BaseService, ICarsService
    {
        private readonly IUsersService _userService;
        private readonly ICryptographyService _cryptographyService;
        private readonly IEmailService _emailService;

        public CarService(DatabaseContext context, IUsersService usersService, ICryptographyService cryptographyService, IEmailService emailService) : base(context)
        {
            _userService = usersService;
            _cryptographyService = cryptographyService;
            _emailService = emailService;
        }

        public async Task<IEnumerable<Car>> GetAllUserCarsAsync(Guid userId)
        {
            var query = from u in Context.UsersCars.Where(x => x.UserId == userId)
                        join car in Context.Cars on u.CarId equals car.CarId
                        let usersCar = Context.UsersCars.Include(x => x.UsersCarsRights).Include(x => x.UsersCarsRoles).Where(x => x.CarId == car.CarId).ToList()
                        let usersCarId = usersCar.Select(x => new { x.UserId, x.UserCarId }).ToList()
                        let users = usersCar.Select(x => x.User.ToDto(usersCarId.First(uc => uc.UserId == x.UserId).UserCarId, x.User.Authentication.Login, x.UsersCarsRights.Select(r => r.RightId).ToList(), x.UsersCarsRoles.Select(r=>r.RoleId).FirstOrDefault())).ToList()
                        select car.ToDto(users);
            return await query.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(Guid idCar)
        {
            return (await Context.Cars.FirstOrDefaultAsync(x => x.CarId == idCar)).ToDto();
        }

        public async Task<Guid> CreateCarAsync(Car car, Guid userId)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    var carToSave = car.ToEntity();
                    await Context.Cars.AddAsync(carToSave);
                    foreach (var userInfo in car.Users)
                    {
                        await Context.UsersCars.AddAsync(new UsersCar() { UserCarId = userInfo.UserCarId, UserId = userId, Car = carToSave });
                        await Context.UsersCarsRoles.AddAsync(new UsersCarsRole(){RoleId = userInfo.RoleId, UserCarId = userInfo.UserCarId });
                        foreach (var rightId in userInfo.RightIds)
                        {
                            await Context.UsersCarsRights.AddAsync(new UsersCarsRight(){RightId = rightId, UserCarId = userInfo.UserCarId });
                        }
                    }
                    await Context.SaveChangesAsync();
                    transaction.Commit();
                    return carToSave.CarId;
                }
                catch
                {
                    transaction.Rollback();
                    return Guid.Empty;
                }
            }
        }

        public async Task<bool> UpdateCarAsync(Car car)
        {
            var carForUpdate = await Context.Cars.Where(x => x.CarId == car.CarId).FirstOrDefaultAsync();
            if (carForUpdate == null)
                return false;
            car.ToEntity(carForUpdate);
            Context.Cars.Update(car.ToEntity(carForUpdate));
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<UserInfo> ShareCarWithOtherUserAsync(Guid carId, string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;
            var userId = await _userService.GetUserIdByLoginAsync(email);
            if (userId == Guid.Empty)
                return null;
            var userFilter = new UserFilter()
            {
                UserId = userId
            };
            var user = (await _userService.GetUsersAsync(userFilter)).FirstOrDefault();
            user = await AddShareCarAsync(user, carId);
            //var message = "Go to the miCarDrive app, a new car was added\n";
            //await _emailService.SendEmailMessageAsync(message, email);
            return user;
        }

        private async Task<UserInfo> AddShareCarAsync(UserInfo user, Guid carId)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    user.UserCarId = Guid.NewGuid();
                    user.RoleId = new Guid("A61EF7D8-FE2A-4390-A453-6027CDC45A7E");
                    user.RightIds = new Guid[] {new Guid("BC962584-7EB9-465E-8269-FAA28985B786")};
                    var userCar = new UsersCar
                    {
                        UserCarId = user.UserCarId,
                        UserId = user.UserId,
                        CarId = carId
                    };
                    await Context.UsersCarsRoles.AddAsync(new UsersCarsRole() { RoleId = user.RoleId, UserCarId = userCar.UserCarId });
                    await Context.UsersCarsRights.AddAsync(new UsersCarsRight() { RightId = user.RightIds.First(), UserCarId = userCar.UserCarId });
                    await Context.UsersCars.AddAsync(userCar);
                    await Context.SaveChangesAsync();
                    transaction.Commit();
                    return user;
                }
                catch
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public async Task<bool> AddShareCarAsync(string encryptString)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(encryptString))
                        return false;

                    var decryptJson = _cryptographyService.DecryptString(encryptString);
                    await Context.UsersCars.AddAsync(new UsersCar
                    {
                        UserId = Guid.Parse(decryptJson.Replace(decryptJson.Remove(36), "")),
                        CarId = Guid.Parse(decryptJson.Remove(36))
                    });
                    await Context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> DeleteShareCarAsync(Guid carId, Guid userId)
        {
            var car = await Context.UsersCars.Where(x => x.UserId == userId && x.CarId == carId).FirstOrDefaultAsync();
            if (car == null)
                return true;
            Context.UsersCars.Remove(car);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
