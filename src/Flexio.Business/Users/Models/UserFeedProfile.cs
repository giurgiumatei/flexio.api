using System.Collections.Generic;

namespace Flexio.Business.Users.Models
{
    public record UserFeedProfile
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string City { get; set; }
        public string Photo { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
