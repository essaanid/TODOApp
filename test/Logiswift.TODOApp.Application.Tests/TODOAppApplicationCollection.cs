using Logiswift.TODOApp.MongoDB;
using Xunit;

namespace Logiswift.TODOApp;

[CollectionDefinition(TODOAppTestConsts.CollectionDefinitionName)]
public class TODOAppApplicationCollection : TODOAppMongoDbCollectionFixtureBase
{

}
