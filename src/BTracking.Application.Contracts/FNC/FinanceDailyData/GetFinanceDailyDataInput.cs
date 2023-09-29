using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BTracking.FNC.FinanceDailyData
{
    public class GetFinanceDailyDataInput : PagedAndSortedResultRequestDto
    {
        public Guid financeId { get; set; }

        public DateTime FilterDate { get; set; }

        public GetFinanceDailyDataInput()
        {

        }
    }

}
