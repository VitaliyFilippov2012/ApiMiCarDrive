using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Business.Interfaces
{
    public interface IServicesService
    {
        Task<IEnumerable<Type>> GetServiceTypes();
    }
}
