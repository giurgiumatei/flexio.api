using System.Collections.Generic;
using Flexio.Business.Comments.Models;

namespace Flexio.Business.Users.Models;

public record UserFeedProfile
{
    public int UserId { get; set; }
    public string DisplayName { get; set; }
    public string City { get; set; }
    public string Photo { get; set; }
    public Comment LastComment { get; set; }
}