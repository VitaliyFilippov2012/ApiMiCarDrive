using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Business.Interfaces
{
    public interface IDetailsService
    {
        Task<IEnumerable<Detail>> GetDetailsByServiceId(Guid serviceId);
    }
}
