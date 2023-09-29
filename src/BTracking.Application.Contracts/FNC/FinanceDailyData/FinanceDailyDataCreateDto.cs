using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BTracking.FNC.FinanceDailyData
{
    public class FinanceDailyDataCreateDto
    {
        [Required]
        public Guid financeId { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}
