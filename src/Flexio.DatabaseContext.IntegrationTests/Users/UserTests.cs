using System;
using System.Collections.Generic;
using System.Linq;
using Flexio.Data;
using Flexio.Data.Models.Users;
using Flexio.TestUtils.Users;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace Flexio.DatabaseContext.IntegrationTests.Users
{
    [TestFixture]
    public class UserTests : BaseTest
    {
        private User _user;
        private string _email = "client@email.com";
        private DateTime _dateAdded = DateTime.UtcNow;

        [SetUp]
        public void SetUp()
        {
            _context.Users.Clear();
            _context.SaveChanges();

            _user = new UserModelBuilder()
                .WithEmail(_email)
                .WithDateAdded(_dateAdded)
                .BuildDataModel();
        }

        [Test]
        public void CanAddUser()
        {
            AddUser(_user);

            var result = GetUsers().Count;

            result.Should().Be(1);
        }

        [Test]
        public void CannotAddTwoUsersWithSameEmail()
        {
            AddUser(_user);

            _context.Users.Add(new UserModelBuilder()
                .WithEmail(_email)
                .WithDateAdded(_dateAdded)
                .BuildDataModel());

            _context.Invoking(x => x.SaveChanges())
                .Should()
                .Throw<Exception>()
                .WithInnerException<SqlException>()
                .WithMessage("Cannot insert duplicate key row in object 'dbo.Users'*");
        }

        private void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        [TearDown]
        public void CleanUsers()
        {
            _context.CleanUpDatabase();
        }
    }
}
