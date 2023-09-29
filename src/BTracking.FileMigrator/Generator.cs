namespace BTracking.FileMigrator
{
    public class Class1
    {


        public void Run()
        {

            var outputDir = "output/";
            var projectName = "BTracking";
            var domainName = "City";


            var template =
@"using {projectName}.Permissions;
using {projectName}.UT.Countries;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.{domainName}s;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace {projectName}.UT.Cities
{
    [Authorize({projectName}Permissions.{domainName}.Default)]
    public class {domainName}AppService : ApplicationService, I{domainName}AppService
    {

        private readonly I{domainName}Repository _cityRepository;

        public {domainName}AppService(I{domainName}Repository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [Authorize({projectName}Permissions.{domainName}.Create)]
        public async Task<{domainName}{domainName}> CreateAsync({domainName}Create{domainName} input)
        {

            var isExist = await _cityRepository.AnyAsync(a => a.CountryId == input.CountryId && a.Name == input.CityName);
            if (isExist)
            {
                throw new UserFriendlyException(L[""{domainName}IdentityExists""]);
            }

            var city = ObjectMapper.Map<{domainName}Create{domainName}, {domainName}>(input);
            city = await _cityRepository.InsertAsync(city, autoSave: true);
            var obj = ObjectMapper.Map<{domainName}, {domainName}{domainName}>(city);

            return obj;

        }

        [Authorize({projectName}Permissions.{domainName}.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _cityRepository.DeleteAsync(id);
        }

        public async Task<{domainName}{domainName}> GetAsync(Guid id)
        {
            var data = (await _cityRepository.GetCityWithDetailAsync(id));
            return ObjectMapper.Map<{domainName}, {domainName}{domainName}>(data);
        }


        public async Task<PagedResult{domainName}<{domainName}{domainName}>> GetListAsync(Get{domainName}Input input)
        {
            var totalCount = await _cityRepository.GetCountAsync(input.FilterText, input.CountryId);
            var items = await _cityRepository.GetListAsync(input.FilterText, input.CountryId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResult{domainName}<{domainName}{domainName}>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<{domainName}>, List<{domainName}{domainName}>>(items)
            };
        }

        [Authorize({projectName}Permissions.{domainName}.Edit)]
        public async Task<{domainName}{domainName}> UpdateAsync(Guid id, {domainName}Update{domainName} input)
        {
            var isExist = await _cityRepository.AnyAsync(a => a.CountryId == input.CountryId && a.Name == input.CityName && a.Id != id);
            if (isExist)
            {
                throw new UserFriendlyException(L[""{domainName}IdentityExists""]);
            }

            var city = await _cityRepository.GetAsync(id);
            ObjectMapper.Map(input, city);
            city = await _cityRepository.UpdateAsync(city, autoSave: true);

            return ObjectMapper.Map<{domainName}, {domainName}{domainName}>(city);
        }
    }
}


";





        }




    }
}




