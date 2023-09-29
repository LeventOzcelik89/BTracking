using BTracking.Permissions;
using BTracking.UT.Countries;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace BTracking.FNC.FinanceDailyData
{
    [Authorize(BTrackingPermissions.Finance.Default)]
    public class FinanceDailyDataAppService : ApplicationService, IFinanceDailyDataAppService
    {

        private readonly IFinanceDailyDataRepository _financeDailyDataRepository;

        public FinanceDailyDataAppService(IFinanceDailyDataRepository financeDailyDataRepository)
        {
            _financeDailyDataRepository = financeDailyDataRepository;
        }

        public Task<FinanceDailyDataDto> BulkCreateAsync(IEnumerable<FinanceDailyDataCreateDto> inputs)
        {
            throw new NotImplementedException();
        }

        [Authorize(BTrackingPermissions.Finance.Create)]
        public async Task<FinanceDailyDataDto> CreateAsync(FinanceDailyDataCreateDto input)
        {

            var isExist = await _financeDailyDataRepository.AnyAsync(a => a.financeId == input.financeId && a.date == input.date);
            if (isExist)
            {
                throw new UserFriendlyException(L["CityIdentityExists"]);
            }

            var finance = ObjectMapper.Map<FinanceDailyDataCreateDto, FinanceDailyData>(input);
            finance = await _financeDailyDataRepository.InsertAsync(finance, autoSave: true);
            var obj = ObjectMapper.Map<FinanceDailyData, FinanceDailyDataDto>(finance);

            return obj;

        }

        [Authorize(BTrackingPermissions.Finance.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _financeDailyDataRepository.DeleteAsync(id);
        }

        public async Task<FinanceDailyDataDto> GetAsync(Guid id)
        {
            var data = (await _financeDailyDataRepository.GetCityWithDetailAsync(id));
            return ObjectMapper.Map<FinanceDailyData, FinanceDailyDataDto>(data);
        }


        public async Task<PagedResultDto<FinanceDailyDataDto>> GetListAsync(GetFinanceDailyDataInput input)
        {
            var totalCount = await _financeDailyDataRepository.GetCountAsync(input.FilterDate, input.financeId);
            var items = await _financeDailyDataRepository.GetListAsync(input.FilterDate, input.financeId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<FinanceDailyDataDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<FinanceDailyData>, List<FinanceDailyDataDto>>(items)
            };
        }

        [Authorize(BTrackingPermissions.Finance.Edit)]
        public async Task<FinanceDailyDataDto> UpdateAsync(Guid id, FinanceDailyDataUpdateDto input)
        {
            var isExist = await _financeDailyDataRepository.AnyAsync(a => a.financeId == input.financeId && a.date == input.date && a.Id != id);
            if (isExist)
            {
                throw new UserFriendlyException(L["CityIdentityExists"]);
            }

            var city = await _financeDailyDataRepository.GetAsync(id);
            ObjectMapper.Map(input, city);
            city = await _financeDailyDataRepository.UpdateAsync(city, autoSave: true);

            return ObjectMapper.Map<FinanceDailyData, FinanceDailyDataDto>(city);
        }
    }
}
