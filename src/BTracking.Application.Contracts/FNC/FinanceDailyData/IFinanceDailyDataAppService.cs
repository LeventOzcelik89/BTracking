using BTracking.UT.Cities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BTracking.FNC.FinanceDailyData
{
    public interface IFinanceDailyDataAppService : IApplicationService
    {
        Task<PagedResultDto<FinanceDailyDataDto>> GetListAsync(GetFinanceDailyDataInput input);

        Task<FinanceDailyDataDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<FinanceDailyDataDto> CreateAsync(FinanceDailyDataCreateDto input);

        Task<FinanceDailyDataDto> UpdateAsync(Guid id, FinanceDailyDataUpdateDto input);

        Task<FinanceDailyDataDto> BulkCreateAsync(IEnumerable<FinanceDailyDataCreateDto> inputs);
    }
}
