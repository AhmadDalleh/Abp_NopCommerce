using NopCommerceV1.Samples;
using Xunit;

namespace NopCommerceV1.EntityFrameworkCore.Applications;

[Collection(NopCommerceV1TestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<NopCommerceV1EntityFrameworkCoreTestModule>
{

}
