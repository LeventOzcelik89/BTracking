using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BTracking.UT.Countries
{
    public interface ICountryRepository : IRepository<Country, Guid>
    {

        Task<List<Country>> GetListAsync(
            string filterText = null,
            string countryCode = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
            );

        Task<long> GetCountAsync(
            string filterText = null,
            string countryCode = null,
            CancellationToken cancellationToken = default
            );

        Task<Country> GetCountryWithDetailAsync(
            Guid id,
            CancellationToken cancellationToken = default
            );

    }
}
