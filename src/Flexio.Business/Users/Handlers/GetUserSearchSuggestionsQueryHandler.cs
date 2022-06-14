using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Business.Users.Models;
using Flexio.Business.Users.Queries;
using Flexio.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flexio.Business.Users.Handlers;

public class GetUserSearchSuggestionsQueryHandler : IRequestHandler<GetUserSearchSuggestionsQuery, IEnumerable<UserSearchSuggestion>>
{
    private readonly FlexioContext _context;

    public GetUserSearchSuggestionsQueryHandler(FlexioContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserSearchSuggestion>> Handle(GetUserSearchSuggestionsQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Users
            .Include(user => user.UserDetail)
            .Where(user => user.UserDetail.DisplayName.ToLower().Contains(request.Name.ToLower()))
            .Select(user => new UserSearchSuggestion
            {
                UserId = user.Id,
                Name = user.UserDetail.DisplayName
            })
            .ToListAsync(cancellationToken);

        return result;
    }
}