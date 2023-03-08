using BTracking.UT.Cities;
using BTracking.UT.Countries;
using BTracking.UT.Towns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace BTracking
{
    [UnitOfWork]
    public class DataSeederConfig : IDataSeedContributor, ITransientDependency
    {

        private TownDataSeedContributor _townDataSeedContributor;
        private CityDataSeedContributor _cityDataSeedContributor;
        private CountryDataSeedContributor _countryDataSeedContributor;

        public DataSeederConfig(
            TownDataSeedContributor townDataSeedContributor,
            CityDataSeedContributor cityDataSeedContributor,
            CountryDataSeedContributor countryDataSeedContributor
            )
        {
            _townDataSeedContributor = townDataSeedContributor;
            _cityDataSeedContributor = cityDataSeedContributor;
            _countryDataSeedContributor = countryDataSeedContributor;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _countryDataSeedContributor.SeedAsync(context);
            await _cityDataSeedContributor.SeedAsync(context);
            await _townDataSeedContributor.SeedAsync(context);
        }
    }
}
