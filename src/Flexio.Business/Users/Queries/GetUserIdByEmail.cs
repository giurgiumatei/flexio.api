using System.Collections.Generic;
using Flexio.Business.Filters;
using Flexio.Business.Users.Models;
using MediatR;

namespace Flexio.Business.Users.Queries;

public class GetUserIdByEmail : IRequest<int?>
{
    public string Email { get; set; }
}