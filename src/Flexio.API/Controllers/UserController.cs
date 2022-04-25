﻿using System.Threading.Tasks;
using Flexio.API.Requests.Users;
using Flexio.API.Requests.Versions;
using Flexio.Business.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flexio.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddUser([FromBody] AddUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(
                new AddUserCommand
                {
                    Email = request.Email,
                    City = request.City,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Country = request.Country,
                    DisplayName = request.DisplayName
                }
                );
            return Ok(result);
        }
    }
}