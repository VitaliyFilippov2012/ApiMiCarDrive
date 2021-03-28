using System.Collections.Generic;
using System.Threading.Tasks;
using DBContext.Models;

namespace Business.Interfaces
{
    public interface IServicesService
    {
        Task<IEnumerable<ServiceType>> GetServiceTypes();
    }
}
