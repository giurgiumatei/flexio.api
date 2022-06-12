using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Business.Comments.Commands;
using Flexio.Data;
using Flexio.Data.Models.Comments;
using MediatR;

namespace Flexio.Business.Comments.Handlers;

public class DeleteCommentsCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
{
    private readonly FlexioContext _context;

    public DeleteCommentsCommandHandler(FlexioContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
    {

        var commentToBeDeleted = _context.Comments
            .FirstOrDefault(comment => comment.Id == command.CommentId);

        if (commentToBeDeleted == null)
        {
            return false;
        }

        _context.Comments.Remove(commentToBeDeleted);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}