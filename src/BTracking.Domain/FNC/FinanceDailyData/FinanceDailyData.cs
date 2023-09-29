using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace BTracking.FNC.FinanceDailyData
{
    public class FinanceDailyData : FullAuditedEntity<Guid>
    {
        public virtual Guid financeId { get; set; }
        public virtual DateTime date { get; set; }
        public virtual double now { get; set; }
        public virtual double open { get; set; }
        public virtual double high { get; set; }
        public virtual double low { get; set; }
        public virtual string cap { get; set; }

        //  public List<Town> CityTowns { get; set; }
        //  public Country CityCountry { get; set; }
    }
}
