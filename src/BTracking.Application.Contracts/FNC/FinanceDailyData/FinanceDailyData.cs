using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BTracking.FNC.FinanceDailyData
{
    public class FinanceDailyDataDto : FullAuditedEntityDto<Guid>
    {
        public Guid financeId { get; set; }
        public DateTime date { get; set; }
        public double now { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public string cap { get; set; }
    }
}
