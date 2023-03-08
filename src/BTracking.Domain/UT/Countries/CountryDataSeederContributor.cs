using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace BTracking.UT.Countries
{
    public class CountryDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        readonly ICountryRepository _countryRepository;
        public CountryDataSeederContributor(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {

            var countryList = (await _countryRepository.GetQueryableAsync()).ToList();

            if (!countryList.Any(a => a.Name == "Türkiye"))
            {
                await _countryRepository.InsertAsync(new Country
                {
                    Name = "Türkiye", 
                    Code = "tr-TR"
                }, autoSave: true);
            }

        }
    }
}
