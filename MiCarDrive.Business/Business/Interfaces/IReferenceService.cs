using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IReferenceService
    {
        Task<IEnumerable<Shared.Models.Type>> GetTransmissionTypesAsync();
        Task<IEnumerable<Shared.Models.Type>> GetFuelTypesAsync();
        Task<IEnumerable<Shared.Models.Type>> GetUserRolesAsync();
        Task<IEnumerable<Shared.Models.Type>> GetUserRightsAsync();
    }
}