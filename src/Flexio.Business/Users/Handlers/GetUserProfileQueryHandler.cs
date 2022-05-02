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

public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfile>
{
    private readonly FlexioContext _context;
    private GetUserProfileQuery _request;
    private User _user;

    public GetUserProfileQueryHandler(FlexioContext context)
    {
        _context = context;
    }

    public async Task<UserProfile> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
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
            .FirstOrDefaultAsync(user => user.Id == _request.UserId);
    }

    private bool UserExists()
    {
        return _context.Users.FirstOrDefault(user => user.Id == _request.UserId) is not null;
    }
}