using BTracking.FNC.FinanceDailyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BTracking.FNC.FinanceDailyData
{
    public interface IFinanceDailyDataRepository : IRepository<FinanceDailyData, Guid>
    {

        Task<List<FinanceDailyData>> GetListAsync(
            DateTime filterDate,
            Guid? financeId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
            );

        Task<long> GetCountAsync(
            DateTime filterDate,
            Guid? financeId = null,
            CancellationToken cancellationToken = default
            );

        Task<FinanceDailyData> GetCityWithDetailAsync(
            Guid id,
            CancellationToken cancellationToken = default
            );

    }
}
