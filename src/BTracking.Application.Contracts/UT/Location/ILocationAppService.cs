using BTracking.UT.Towns;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BTracking.UT.Location
{
    public interface ILocationAppService
    {
        Task<PagedResultDto<TownDto>> GetListAsync(GetTownInput input);

        Task<TownDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<TownDto> CreateAsync(TownCreateDto input);

        Task<TownDto> UpdateAsync(Guid id, TownUpdateDto input);
    }
}
