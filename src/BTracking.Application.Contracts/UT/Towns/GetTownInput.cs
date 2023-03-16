using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BTracking.UT.Towns
{
    public class GetTownInput : PagedAndSortedResultRequestDto
    {
        public Guid CityId { get; set; }

        public string FilterText { get; set; }

        public GetTownInput()
        {

        }
    }

}
