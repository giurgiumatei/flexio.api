using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexio.Business.Users.Models
{
    public record Comment
    {
        public int CommentId { get; set; }
        public string DisplayName { get; set; }
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsAnonymous { get; set; }
    }
}
