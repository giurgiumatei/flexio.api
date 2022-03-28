using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flexio.Data.Models.Users;

namespace Flexio.TestUtils.Users
{
    public class UserModelBuilder
    {
        private string _email = "test_email@yahoo.com";
        private DateTime _dateAdded = DateTime.UtcNow;

        public User BuildDataModel()
        {
            return new User
            {
                Email = _email,
                DateAdded = _dateAdded
            };
        }

        public UserModelBuilder WithEmail(string email)
        {
            _email = email;

            return this;
        }

        public UserModelBuilder WithDateAdded(DateTime date)
        {
            _dateAdded = date;

            return this;
        }
    }
}
