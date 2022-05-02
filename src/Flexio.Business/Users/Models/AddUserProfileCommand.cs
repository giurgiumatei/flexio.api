using System.Collections.Generic;
using System.IO;
using Flexio.Data.Models.Users;
using MediatR;

namespace Flexio.Business.Users.Models;

public record AddUserProfileCommand : IRequest<bool>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public Gender GenderId { get; set; }
    public Stream ProfileImage { get; set; }
}