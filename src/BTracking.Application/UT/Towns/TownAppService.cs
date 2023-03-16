using AutoMapper.Internal.Mappers;
using BTracking.Permissions;
using BTracking.UT.Cities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace BTracking.UT.Towns
{


    [Authorize(BTrackingPermissions.Town.Default)]
    public class TownAppService : ApplicationService, ITownAppService
    {

        private readonly ITownRepository _townRepository;

        public TownAppService(ITownRepository townRepository)
        {
            _townRepository = townRepository;
        }

        [Authorize(BTrackingPermissions.Town.Create)]
        public async Task<TownDto> CreateAsync(TownCreateDto input)
        {

            var isExist = await _townRepository.AnyAsync(a => a.CityId == input.CityId && a.Name == input.TownName);
            if (isExist)
            {
                throw new UserFriendlyException(L["TownIdentityExists"]);
            }

            var Town = ObjectMapper.Map<TownCreateDto, Town>(input);
            Town = await _townRepository.InsertAsync(Town, autoSave: true);
            var obj = ObjectMapper.Map<Town, TownDto>(Town);

            return obj;

        }

        [Authorize(BTrackingPermissions.Town.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _townRepository.DeleteAsync(id);
        }

        public async Task<TownDto> GetAsync(Guid id)
        {
            var data = (await _townRepository.GetTownWithDetailAsync(id));
            return ObjectMapper.Map<Town, TownDto>(data);
        }


        public async Task<PagedResultDto<TownDto>> GetListAsync(GetTownInput input)
        {
            var totalCount = await _townRepository.GetCountAsync(input.FilterText, input.CityId);
            var items = await _townRepository.GetListAsync(input.FilterText, input.CityId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TownDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Town>, List<TownDto>>(items)
            };
        }

        [Authorize(BTrackingPermissions.Town.Edit)]
        public async Task<TownDto> UpdateAsync(Guid id, TownUpdateDto input)
        {
            var isExist = await _townRepository.AnyAsync(a => a.CityId == input.CityId && a.Name == input.TownName && a.Id != id);
            if (isExist)
            {
                throw new UserFriendlyException(L["TownIdentityExists"]);
            }

            var Town = await _townRepository.GetAsync(id);
            ObjectMapper.Map(input, Town);
            Town = await _townRepository.UpdateAsync(Town, autoSave: true);

            return ObjectMapper.Map<Town, TownDto>(Town);
        }
    }

}
