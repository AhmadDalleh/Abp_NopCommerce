using Microsoft.AspNetCore.Builder;
using NopCommerceV1;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();

builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("NopCommerceV1.Web.csproj");
await builder.RunAbpModuleAsync<NopCommerceV1WebTestModule>(applicationName: "NopCommerceV1.Web" );

public partial class Program
{
}
