namespace Flexio.Data.Models.Users;

public class UserDetail
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string DisplayName { get; set; }
    public string ProfileImageUrl { get; set; }
    public Role RoleId { get; set; }
    public Gender GenderId { get; set; }

    public User User { get; set; }
}