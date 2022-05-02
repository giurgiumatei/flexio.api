using System.Collections.Generic;
using Flexio.Business.Filters;
using Flexio.Business.Users.Models;
using MediatR;

namespace Flexio.Business.Users.Queries;

public class GetUserProfileQuery : IRequest<UserProfile>
{
    public int UserId { get; set; }
}