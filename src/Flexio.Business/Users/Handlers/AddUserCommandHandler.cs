using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Business.Users.Commands;
using Flexio.Data;
using Flexio.Data.Models.Users;
using MediatR;

namespace Flexio.Business.Users.Handlers;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
{
    private readonly FlexioContext _context;

    public AddUserCommandHandler(FlexioContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(AddUserCommand command, CancellationToken cancellationToken)
    {
        if (_context.Users.FirstOrDefault(u => u.Email == command.Email) != null)
        {
            return false;
        }

        _context.Users.Add(new User
        {
            Email = command.Email,
            DateAdded = DateTime.Now,
            UserDetail = new UserDetail
            {
                City = command.City,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Country = command.Country,
                DisplayName = command.DisplayName
            }
        });

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}