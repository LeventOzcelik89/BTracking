using BTracking.UT.Cities;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace BTracking.UT.Towns
{
    public class Town : FullAuditedEntity<Guid>
    {
        public virtual Guid CityId { get; set; }
        public virtual string Name { get; set; }
        [DisableAuditing]
        public virtual Geometry Shape { get; set; }

        public City TownCity { get; set; }
    }
}
