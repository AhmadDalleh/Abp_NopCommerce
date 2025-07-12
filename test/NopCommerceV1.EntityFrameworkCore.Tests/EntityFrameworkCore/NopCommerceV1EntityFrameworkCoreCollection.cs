using Xunit;

namespace NopCommerceV1.EntityFrameworkCore;

[CollectionDefinition(NopCommerceV1TestConsts.CollectionDefinitionName)]
public class NopCommerceV1EntityFrameworkCoreCollection : ICollectionFixture<NopCommerceV1EntityFrameworkCoreFixture>
{

}
