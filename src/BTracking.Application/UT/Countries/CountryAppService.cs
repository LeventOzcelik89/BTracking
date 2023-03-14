using BTracking.Permissions;
using Microsoft.AspNetCore.Authorization;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace BTracking.UT.Countries
{
    [Authorize(BTrackingPermissions.Country.Default)]
    public class CountryAppService : ApplicationService, ICountryAppService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryAppService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [Authorize(BTrackingPermissions.Country.Create)]
        public virtual async Task<CountryDto> CreateAsync(CountryCreateDto input)
        {
            var isExist = await _countryRepository.AnyAsync(a => a.Code == input.CountryCode);
            if (isExist)
            {
                throw new UserFriendlyException(L["CountryIdentityExists"]);
            }

            var country = ObjectMapper.Map<CountryCreateDto, Country>(input);
            country = await _countryRepository.InsertAsync(country, autoSave: true);
            var obj = ObjectMapper.Map<Country, CountryDto>(country);

            return obj;

        }

        [Authorize(BTrackingPermissions.Country.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _countryRepository.DeleteAsync(id);
        }

        public virtual async Task<CountryDto> GetAsync(Guid id)
        {
            var data = (await _countryRepository.GetCountryWithDetailAsync(id));
            return ObjectMapper.Map<Country, CountryDto>(data);
        }

        public virtual async Task<PagedResultDto<CountryDto>> GetListAsync(GetCountryInput input)
        {
            var totalCount = await _countryRepository.GetCountAsync(input.FilterText, input.CountryCode);
            var items = await _countryRepository.GetListAsync(input.FilterText, input.CountryCode, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CountryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Country>, List<CountryDto>>(items)
            };
        }

        [Authorize(BTrackingPermissions.Country.Edit)]
        public virtual async Task<CountryDto> UpdateAsync(Guid id, CountryUpdateDto input)
        {
            var isExist = await _countryRepository.AnyAsync(a => a.Code == input.CountryCode && a.Id != id);
            if (isExist)
            {
                throw new UserFriendlyException(L["CountryIdentityExists"]);
            }

            var country = await _countryRepository.GetAsync(id);
            ObjectMapper.Map(input, country);
            country = await _countryRepository.UpdateAsync(country, autoSave: true);

            return ObjectMapper.Map<Country, CountryDto>(country);
        }
    }
}
