using System;
using System.Threading.Tasks;
using Flexio.API.Requests.Comments;
using Flexio.Business.Comments.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flexio.API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<bool>> AddComment([FromBody] AddCommentRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(
            new AddCommentCommand
            {
                DisplayName = request.DisplayName,
                Email = request.Email,
                Text = request.Text,
                IsAnonymous = request.IsAnonymous,
                AddedToUserId = request.AddedToUserId,
                DateAdded = DateTime.Now
            }
        );
        return Ok(result);
    }
}