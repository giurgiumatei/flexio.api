using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Azure.Graph.Services;
using Flexio.Azure.Storage.Services;
using Flexio.Business.Users.Commands;
using Flexio.Data;
using Flexio.Data.Models.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flexio.Business.Users.Handlers;

public class TakeOverUserProfileCommandHandler : IRequestHandler<TakeOverUserProfileCommand, bool>
{
    private readonly FlexioContext _context;
    private readonly IGraphUserManager _graphUserManager;

    public TakeOverUserProfileCommandHandler(FlexioContext context, IGraphUserManager graphUserManager)
    {
        _context = context;
        _graphUserManager = graphUserManager;
    }

    public async Task<bool> Handle(TakeOverUserProfileCommand command, CancellationToken cancellationToken)
    {
        var user = _context.Users
            .Include(user => user.UserDetail)
            .FirstOrDefault(user => user.Id == command.UserId);

        if (user != null) user.Email = command.Email;

        AddUserToAzure(user, command.Password);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public void AddUserToAzure(User user, string password)
    {
        _graphUserManager.AddUser(user, password);
    }
}