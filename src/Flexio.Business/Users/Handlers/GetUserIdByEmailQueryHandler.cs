using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Business.Users.Queries;
using Flexio.Data;
using MediatR;

namespace Flexio.Business.Users.Handlers;

public class GetUserIdByEmailQueryHandler : IRequestHandler<GetUserIdByEmail, int?>
{
    private readonly FlexioContext _context;
    private GetUserIdByEmail _request;

    public GetUserIdByEmailQueryHandler(FlexioContext context)
    {
        _context = context;
    }

    public Task<int?> Handle(GetUserIdByEmail request, CancellationToken cancellationToken)
    {
        _request = request;

        return Task.FromResult(!UserExists() ? null : _context.Users.FirstOrDefault(user => user.Email == _request.Email)?.Id);
    }

    private bool UserExists()
    {
        return _context.Users.FirstOrDefault(user => user.Email == _request.Email) is not null;
    }
}