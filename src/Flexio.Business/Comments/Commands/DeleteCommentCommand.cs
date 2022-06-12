using System;
using MediatR;

namespace Flexio.Business.Comments.Commands;

public class DeleteCommentCommand : IRequest<bool>
{
    public int CommentId { get; set; }
}