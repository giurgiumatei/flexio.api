using AutoFixture;
using Flexio.Data;
using Flexio.TestUtils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexio.DatabaseContext.IntegrationTests
{
    public class BaseTest : IDisposable
    {
        protected FlexioContext _context;
        protected string _connectionString;
        private TestContextFactory _factory;
        protected Fixture _fixture;

        public BaseTest()
        {
            _factory = new TestContextFactory();
            _connectionString = _factory.GetConnectionString();
            _factory.CreateDatabase();
            _context = _factory._context;

            _fixture = new Fixture().GetFixtureCustomizedForEntityFramework();
        }

        public void Dispose()
        {
            _factory.DeleteDatabase();
        }
    }
}
