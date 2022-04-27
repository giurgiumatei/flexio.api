using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flexio.Data.Models.Users;

namespace Flexio.TestUtils.Users
{
    public class UserDetailModelBuilder
    {
        private Role _roleId = Role.Client;
        private int _creatorId = 1;
        private int _actualOwnerId = 1;
        private string _firstName = "FirstName";
        private string _lastName = "LastName";
        private string _city = "City";
        private string _country = "Country";
        private string _displayName = "DisplayName";

        public UserDetailModelBuilder WithRole(Role role)
        {
            _roleId = role;

            return this;
        }

        public UserDetailModelBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;

            return this;
        }

        public UserDetailModelBuilder WithLastName(string lastName)
        {
            _lastName = lastName;

            return this;
        }

        public UserDetailModelBuilder WithCity(string city)
        {
            _city = city;

            return this;
        }

        public UserDetailModelBuilder WithCountry(string country)
        {
            _country = country;

            return this;
        }

        public UserDetailModelBuilder WithDisplayName(string displayName)
        {
            _displayName = displayName;

            return this;
        }
    }
}
