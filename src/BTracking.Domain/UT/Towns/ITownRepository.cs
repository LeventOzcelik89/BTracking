using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BTracking.UT.Towns
{
    public interface ITownRepository : IRepository<Town, Guid>
    {

        Task<List<Town>> GetListAsync(
            string filterText = null,
            Guid? cityId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
            );

        Task<long> GetCountAsync(
            string filterText = null,
            Guid? cityId = null,
            CancellationToken cancellationToken = default
            );

        Task<Town> GetTownWithDetailAsync(
            Guid id,
            CancellationToken cancellationToken = default
            );

    }
}
