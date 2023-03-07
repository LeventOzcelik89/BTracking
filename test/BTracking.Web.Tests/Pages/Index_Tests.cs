using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace BTracking.Pages;

public class Index_Tests : BTrackingWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
