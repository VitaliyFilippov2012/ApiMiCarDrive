using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Business.Interfaces
{
    public interface ICarsService
    {
        Task<IEnumerable<Car>> GetAllUserCarsAsync(Guid userId);
        Task<Car> GetCarByIdAsync(Guid idCar);
        Task<Guid> CreateCarAsync(Car car, Guid userId);
        Task<bool> UpdateCarAsync(Car car);
        Task<UserInfo> ShareCarWithOtherUserAsync(Guid carId, string email);
        Task<bool> AddShareCarAsync(string encryptString);
        Task<bool> DeleteShareCarAsync(Guid carId, Guid userId);
    }
}
