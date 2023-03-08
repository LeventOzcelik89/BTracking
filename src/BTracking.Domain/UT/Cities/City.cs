using BTracking.UT.Countries;
using BTracking.UT.Towns;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace BTracking.UT.Cities
{
    public class City : FullAuditedEntity<Guid>
    {
        public virtual Guid CountryId { get; set; }

        public virtual string Name { get; set; }
        [DisableAuditing]
        public virtual Geometry Shape { get; set; }


        public List<Town> CityTowns { get; set; }
        public Country CityCountry { get; set; }
    }
}
