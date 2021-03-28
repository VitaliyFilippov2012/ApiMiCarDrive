using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.AutoMapper;
using Business.Interfaces;
using DBContext.Context;
using DBContext.Models;
using Microsoft.EntityFrameworkCore;
using Car = Shared.Models.Car;

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

        public async Task<IEnumerable<Car>> GetAllUserCarsAsync(Guid userid)
        {
            return (await Context.UsersCars.Include(x => x.Car).Include(x => x.CarEvents).Where(x => x.UserId == userid).Select(x => x.Car).ToListAsync()).ToDtoList();
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
                    await Context.UsersCars.AddAsync(new UsersCar() { UserId = userId, Car = carToSave });
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

        public async Task<bool> ShareCarWithOtherUserAsync(Guid carId, string email, string uri)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            var userId = await _userService.GetUserByLoginAsync(email);
            if (userId == Guid.Empty)
                return false;
            var json = carId + userId.ToString();
            var encryptJson = _cryptographyService.EncryptString(json);
            var message = "Follow the link to add a common car\n Link: " + uri + encryptJson;
            await _emailService.SendEmailMessageAsync(message, email);
            return true;
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
