using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexio.Data.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime LinkSetDate { get; set; }
        public string Token { get; set; }

        public UserDetail UserDetail { get; set; }
        public UserDetail CreatorDetail { get; set; }
        public UserDetail ActualOwnerDetail { get; set; }
    }
}
