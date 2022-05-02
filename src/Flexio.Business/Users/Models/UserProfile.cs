using System.Collections.Generic;

namespace Flexio.Business.Users.Models;

public record UserProfile
{
    public int UserId { get; set; }
    public string DisplayName { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Gender { get; set; }
    public string Photo { get; set; }
    public List<Comment> Comments { get; set; }
}