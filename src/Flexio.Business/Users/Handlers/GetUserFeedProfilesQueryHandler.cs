using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Business.Users.Models;
using Flexio.Business.Users.Queries;
using Flexio.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flexio.Business.Users.Handlers;

public class GetUserFeedProfilesQueryHandler : IRequestHandler<GetUserFeedProfilesQuery, IEnumerable<UserFeedProfile>>
{
    private readonly FlexioContext _context;

    public GetUserFeedProfilesQueryHandler(FlexioContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserFeedProfile>> Handle(GetUserFeedProfilesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Users
            .Include(user => user.UserDetail)
            .Include(user => user.CommentsAddedToUser)
            .ThenInclude(comment => comment.AddedByUser).ThenInclude(addedByUser => addedByUser.UserDetail)
            .ToUserFeedProfiles();

        var data = query.GetPage(request.DataFilterQuery.PageNumber, request.DataFilterQuery.PageSize);

        var result = await data.ToListAsync(cancellationToken);

        return result;
    }
}