using BTracking.UT.Cities;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace BTracking.UT.Countries
{
    public class Country : FullAuditedEntity<Guid>
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        [DisableAuditing]
        public virtual Geometry Shape { get; set; }


        public List<City> CountryCities { get; set; }
    }
}
