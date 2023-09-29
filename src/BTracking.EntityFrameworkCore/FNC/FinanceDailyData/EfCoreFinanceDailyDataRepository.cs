using BTracking.EntityFrameworkCore;
using BTracking.FNC.FinanceDailyData;
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
    public class EfCoreFinanceDailyDataRepository : EfCoreRepository<BTrackingDbContext, FinanceDailyData, Guid>, IFinanceDailyDataRepository
    {
        public EfCoreFinanceDailyDataRepository(IDbContextProvider<BTrackingDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        protected virtual IQueryable<FinanceDailyData> ApplyFilter(
            IQueryable<FinanceDailyData> query,
            DateTime filterDate)
        {
            return query
                    .Where(e => e.date == filterDate);
        }

        public async Task<long> GetCountAsync(
            DateTime filterDate,
            Guid? countryId = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(await GetDbSetAsync(), filterDate);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<FinanceDailyData> GetCityWithDetailAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();
                //.Include(a => a.CityTowns);
            var rs = await dbSet.Where(a => a.Id == id).FirstOrDefaultAsync(cancellationToken);
            return rs;
        }

        public async Task<List<FinanceDailyData>> GetListAsync(
            DateTime filterDate,
            Guid? countryId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(await GetQueryableAsync(), filterDate);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? FinanceDailyDataConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

    }
}
