using AutoFixture;
using Flexio.Data;
using Flexio.TestUtils.Helpers;


namespace Flexio.Business.IntegrationTests.Api
{
    public static class TestContextExtensions
    {
        private static Fixture _fixture;

        static TestContextExtensions()
        {
            _fixture = new Fixture()
                .GetFixtureCustomizedForEntityFramework();
        }

        public static void CleanUpDatabase(this FlexioContext context)
        {
            context.Database.EnsureDeleted();
        }
    }
}
