using System.Collections.Generic;
using Flexio.Business.Filters;
using Flexio.Business.Users.Models;
using MediatR;

namespace Flexio.Business.Users.Queries
{
    public class GetUserFeedProfilesQuery : IRequest<IEnumerable<UserFeedProfile>>
    {
        public DataFilterQuery DataFilterQuery { get; set; }
    }
}
