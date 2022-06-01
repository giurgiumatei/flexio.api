namespace Flexio.API.Requests.Users;

public class TakeOverUserProfileRequest
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}