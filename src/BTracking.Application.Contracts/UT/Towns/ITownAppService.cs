using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BTracking.UT.Towns
{
    public interface ITownAppService : IApplicationService
    {
        Task<PagedResultDto<TownDto>> GetListAsync(GetTownInput input);

        Task<TownDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<TownDto> CreateAsync(TownCreateDto input);

        Task<TownDto> UpdateAsync(Guid id, TownUpdateDto input);
    }
}