using BTracking.EntityFrameworkCore;
using BTracking.UT.Countries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BTracking.UT.Cities
{
    public class EfCoreCityRepository : EfCoreRepository<BTrackingDbContext, City, Guid>, ICityRepository
    {
        public EfCoreCityRepository(IDbContextProvider<BTrackingDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        protected virtual IQueryable<City> ApplyFilter(
            IQueryable<City> query,
            string filterText)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText));
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? countryId = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(await GetDbSetAsync(), filterText);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<City> GetCityWithDetailAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbSet = (await GetDbSetAsync())
                .Include(a => a.CityTowns);
            var rs = await dbSet.Where(a => a.Id == id).FirstOrDefaultAsync(cancellationToken);
            return rs;
        }

        public async Task<List<City>> GetListAsync(
            string filterText = null,
            Guid? countryId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(await GetQueryableAsync(), filterText);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CityConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

    }
}
