using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexio.Business.Users.Models;

public record UserSearchSuggestion
{
    public int UserId { get; set; }
    public string Name { get; set; }
}