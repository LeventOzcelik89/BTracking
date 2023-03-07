using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BTracking.UT.Countries
{
    public interface ICountryAppService : IApplicationService
    {
        Task<PagedResultDto<CountryDto>> GetListAsync(GetCountryInput input);

        Task<CountryDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CountryDto> CreateAsync(CountryCreateDto input);

        Task<CountryDto> UpdateAsync(Guid id, CountryUpdateDto input);

    }
}
