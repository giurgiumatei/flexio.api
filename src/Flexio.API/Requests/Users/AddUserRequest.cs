using System;

namespace Flexio.API.Requests.Users
{
    public class AddUserRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
