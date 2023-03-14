using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BTracking.UT.Cities
{
    public interface ICityAppService : IApplicationService
    {
        Task<PagedResultDto<CityDto>> GetListAsync(GetCityInput input);

        Task<CityDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CityDto> CreateAsync(CityCreateDto input);

        Task<CityDto> UpdateAsync(Guid id, CityUpdateDto input);
    }
}