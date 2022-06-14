using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Flexio.API.Requests.Users;
using Flexio.API.Requests.Versions;
using Flexio.Business.Filters;
using Flexio.Business.Users;
using Flexio.Business.Users.Commands;
using Flexio.Business.Users.Models;
using Flexio.Business.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flexio.API.Controllers;

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

    [AllowAnonymous]
    [HttpGet("get-user-feed-profiles")]
    public async Task<ActionResult<IEnumerable<UserFeedProfile>>> GetUserFeedProfiles(int pageNumber, int pageSize)
    {
        var result = await _mediator.Send(new GetUserFeedProfilesQuery
        {
            DataFilterQuery = new DataFilterQuery {PageNumber = pageNumber, PageSize = pageSize}
        });

        return result is not null ? Ok(result) : NotFound();
    }

    [AllowAnonymous]
    [HttpGet("userProfile")]
    public async Task<ActionResult<UserProfile>> GetUserProfile(int userId, string currentUserEmail)
    {
        var result = await _mediator.Send(new GetUserProfileQuery
        {
            UserId = userId,
            CurrentUserEmail = currentUserEmail
        });

        return Ok(result);
    }

    [HttpGet("userId")]
    public async Task<ActionResult<UserProfile>> GetUserIdByEmail(string email)
    {
        var result = await _mediator.Send(new GetUserIdByEmail
        {
            Email = email
        });

        return Ok(result);
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

    [AllowAnonymous]
    [HttpPost("userProfile")]
    public async Task<ActionResult<bool>> AddUserProfile([FromForm] AddUserProfileRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(
            new AddUserProfileCommand
            {
                City = request.City,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Country = request.Country,
                GenderId = request.GenderId,
                ProfileImage = await FileUtils.ToMemoryStream(request.ProfileImage)
            }
        );
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("takeOverUserProfile")]
    public async Task<ActionResult<bool>> TakeOverUserProfile([FromBody] TakeOverUserProfileRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(
            new TakeOverUserProfileCommand
            {
                UserId = request.UserId,
                Email = request.Email,
                Password = request.Password
            }
        );
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<UserSearchSuggestion>>> SearchUserProfile(string name)
    {
        var result = await _mediator.Send(new GetUserSearchSuggestionsQuery
        {
            Name = name
        });

        return Ok(result);
    }
}