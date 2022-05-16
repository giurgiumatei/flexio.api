using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Business.Users.Models;
using Flexio.Business.Users.Queries;
using Flexio.Data;
using Flexio.Data.Models.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flexio.Business.Users.Handlers;

public class GetUserProfileByEmailQueryHandler : IRequestHandler<GetUserProfileByEmailQuery, UserProfile>
{
    private readonly FlexioContext _context;
    private GetUserProfileByEmailQuery _request;
    private User _user;

    public GetUserProfileByEmailQueryHandler(FlexioContext context)
    {
        _context = context;
    }

    public async Task<UserProfile> Handle(GetUserProfileByEmailQuery request, CancellationToken cancellationToken)
    {
        _request = request;

        if (!UserExists())
        {
            return null;
        }

        await LoadData();

        return _user.ToUserProfile();
    }

    private async Task LoadData()
    {
        _user = await _context.Users
            .Include(user => user.UserDetail)
            .Include(user => user.CommentsAddedToUser)
            .ThenInclude(comment => comment.AddedByUser).ThenInclude(addedByUser => addedByUser.UserDetail)
            .FirstOrDefaultAsync(user => user.Email == _request.Email);
    }

    private bool UserExists()
    {
        return _context.Users.FirstOrDefault(user => user.Email == _request.Email) is not null;
    }
}