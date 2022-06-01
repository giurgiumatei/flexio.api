using MediatR;

namespace Flexio.Business.Users.Commands;

public class TakeOverUserProfileCommand : IRequest<bool>
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}