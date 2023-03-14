using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BTracking.UT.Cities
{
    public interface ICityRepository : IRepository<City, Guid>
    {

        Task<List<City>> GetListAsync(
            string filterText = null,
            Guid? countryId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
            );

        Task<long> GetCountAsync(
            string filterText = null,
            Guid? countryId = null,
            CancellationToken cancellationToken = default
            );

        Task<City> GetCityWithDetailAsync(
            Guid id,
            CancellationToken cancellationToken = default
            );

    }
}
