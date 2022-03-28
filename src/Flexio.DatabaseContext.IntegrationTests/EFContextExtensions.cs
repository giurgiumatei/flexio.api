using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Flexio.Data;
using Flexio.TestUtils.Helpers;

namespace Flexio.DatabaseContext.IntegrationTests
{
    public static class EFContextExtensions
    {
        private static Fixture _fixture;

        static EFContextExtensions()
        {
            _fixture = new Fixture().GetFixtureCustomizedForEntityFramework();
        }

        public static void CleanUpDatabase(this FlexioContext context)
        {
            context.ChangeTracker.Clear();
            context.UserDetails.Clear();
            context.Users.Clear();
        }
    }
}
