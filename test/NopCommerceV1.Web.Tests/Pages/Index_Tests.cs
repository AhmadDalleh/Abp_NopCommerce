using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace NopCommerceV1.Pages;

public class Index_Tests : NopCommerceV1WebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
