using System;
using MediatR;

namespace Flexio.Business.Comments.Commands;

public class AddCommentCommand : IRequest<bool>
{
    public string DisplayName { get; set; }
    public string Email { get; set; }
    public string Text { get; set; }
    public bool IsAnonymous { get; set; }
    public int AddedToUserId { get; set; }
    public DateTime DateAdded { get; set; }
}