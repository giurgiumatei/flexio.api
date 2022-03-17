﻿using System;
using MediatR;

namespace Flexio.Business.Users.Commands
{
    public class AddUserCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string DisplayName { get; set; }
    }
}
