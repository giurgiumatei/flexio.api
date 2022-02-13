using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexio.Data.Models.Users
{
    public class UserDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CreatorId { get; set; }
        public int ActualOwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public DateTime DateModified { get; set; }


        public User User { get; set; }
        public User Creator { get; set; }
        public User ActualOwner { get; set; }
    }
}
