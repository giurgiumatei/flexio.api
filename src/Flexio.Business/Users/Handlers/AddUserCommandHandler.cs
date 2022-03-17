using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Business.Users.Commands;
using Flexio.Business.Versions;
using Flexio.Business.Versions.Models;
using Flexio.Business.Versions.Queries;
using Flexio.Data;
using Flexio.Data.Models.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flexio.Business.Users.Handlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
    {
        private readonly FlexioContext _context;

        public AddUserCommandHandler(FlexioContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            _context.Users.Add(new User
            {
                Email = command.Email,
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
}
