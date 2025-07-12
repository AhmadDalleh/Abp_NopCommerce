using NopCommerceV1.Samples;
using Xunit;

namespace NopCommerceV1.EntityFrameworkCore.Domains;

[Collection(NopCommerceV1TestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<NopCommerceV1EntityFrameworkCoreTestModule>
{

}
