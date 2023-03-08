using BTracking.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BTracking.UT.Countries
{

    public class EfCoreCountryRepository : EfCoreRepository<BTrackingDbContext, Country, Guid>, ICountryRepository
    {
        public EfCoreCountryRepository(IDbContextProvider<BTrackingDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        protected virtual IQueryable<Country> ApplyFilter(
            IQueryable<Country> query,
            string filterText,
            string countryCode = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(countryCode), e => e.Code.Contains(countryCode));
        }

        public async Task<long> GetCountAsync(
            string filterText = null, 
            string countryCode = null, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(await GetDbSetAsync(), filterText, countryCode);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Country> GetCountryWithDetailAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbSet = (await GetDbSetAsync())
                .Include(c => c.CountryCities);
            var rs = await dbSet.Where(a => a.Id == id).FirstOrDefaultAsync(cancellationToken);
            return rs;
        }

        public async Task<List<Country>> GetListAsync(
            string filterText = null, 
            string countryCode = null, 
            string sorting = null, 
            int maxResultCount = int.MaxValue, 
            int skipCount = 0, 
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(await GetQueryableAsync(), filterText, countryCode);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CountryConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }
    }

}
