using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Business.Users.Models;
using Flexio.Business.Users.Queries;
using Flexio.Data;
using MediatR;

namespace Flexio.Business.Users.Handlers
{
    public class GetUserFeedProfilesQueryHandler : IRequestHandler<GetUserFeedProfilesQuery, IEnumerable<UserFeedProfile>>
    {
        private readonly FlexioContext _context;

        public GetUserFeedProfilesQueryHandler(FlexioContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<UserFeedProfile>> Handle(GetUserFeedProfilesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
