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

namespace BTracking.UT.Cities
{
    [Authorize(BTrackingPermissions.City.Default)]
    public class CityAppService : ApplicationService, ICityAppService
    {

        private readonly ICityRepository _cityRepository;

        public CityAppService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [Authorize(BTrackingPermissions.City.Create)]
        public async Task<CityDto> CreateAsync(CityCreateDto input)
        {

            var isExist = await _cityRepository.AnyAsync(a => a.CountryId == input.CountryId && a.Name == input.CityName);
            if (isExist)
            {
                throw new UserFriendlyException(L["CityIdentityExists"]);
            }

            var city = ObjectMapper.Map<CityCreateDto, City>(input);
            city = await _cityRepository.InsertAsync(city, autoSave: true);
            var obj = ObjectMapper.Map<City, CityDto>(city);

            return obj;

        }

        [Authorize(BTrackingPermissions.City.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _cityRepository.DeleteAsync(id);
        }

        public async Task<CityDto> GetAsync(Guid id)
        {
            var data = (await _cityRepository.GetCityWithDetailAsync(id));
            return ObjectMapper.Map<City, CityDto>(data);
        }


        public async Task<PagedResultDto<CityDto>> GetListAsync(GetCityInput input)
        {
            var totalCount = await _cityRepository.GetCountAsync(input.FilterText, input.CountryId);
            var items = await _cityRepository.GetListAsync(input.FilterText, input.CountryId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CityDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<City>, List<CityDto>>(items)
            };
        }

        [Authorize(BTrackingPermissions.City.Edit)]
        public async Task<CityDto> UpdateAsync(Guid id, CityUpdateDto input)
        {
            var isExist = await _cityRepository.AnyAsync(a => a.CountryId == input.CountryId && a.Name == input.CityName && a.Id != id);
            if (isExist)
            {
                throw new UserFriendlyException(L["CityIdentityExists"]);
            }

            var city = await _cityRepository.GetAsync(id);
            ObjectMapper.Map(input, city);
            city = await _cityRepository.UpdateAsync(city, autoSave: true);

            return ObjectMapper.Map<City, CityDto>(city);
        }
    }
}
