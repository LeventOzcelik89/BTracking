using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BTracking.FNC.FinanceDailyData
{
    public class FinanceDailyDataUpdateDto
    {
        [Required]
        public Guid financeId { get; set; }
        [Required]
        public DateTime date { get; set; }
        public double now { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public string cap { get; set; }
    }
}
