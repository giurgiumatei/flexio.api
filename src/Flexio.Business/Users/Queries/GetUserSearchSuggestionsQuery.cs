using System.Collections.Generic;
using Flexio.Business.Users.Models;
using MediatR;

namespace Flexio.Business.Users.Queries;

public class GetUserSearchSuggestionsQuery : IRequest<IEnumerable<UserSearchSuggestion>>
{
    public string Name { get; set; }
}