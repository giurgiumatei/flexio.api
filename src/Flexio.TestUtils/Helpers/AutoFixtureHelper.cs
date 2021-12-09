using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;

namespace Flexio.TestUtils.Helpers
{
    public static class AutoFixtureHelper
    {
        public static Fixture GetFixtureCustomizedForEntityFramework(this Fixture fixture)
        {
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            fixture.AddModelConstrainsToFixture();
            return fixture;
        }

        public static Fixture GetFixtureCustomizedForMockedContext(this Fixture fixture)
        {
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            fixture.AddModelConstrainsToFixture();
            return fixture;
        }

        public static Fixture AddModelConstrainsToFixture(this Fixture fixture)
        {

            return fixture;
        }

    }
}
