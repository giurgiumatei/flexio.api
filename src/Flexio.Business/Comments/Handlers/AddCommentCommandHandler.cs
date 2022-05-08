using System;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Business.Comments.Commands;
using Flexio.Business.Users.Commands;
using Flexio.Data;
using Flexio.Data.Models.Comments;
using Flexio.Data.Models.Users;
using MediatR;

namespace Flexio.Business.Comments.Handlers;

public class AddCommentsCommandHandler : IRequestHandler<AddCommentCommand, bool>
{
    private readonly FlexioContext _context;

    public AddCommentsCommandHandler(FlexioContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(AddCommentCommand command, CancellationToken cancellationToken)
    {
        _context.Comments.Add(new Comment
        {
            Text = command.Text,
            DateAdded = command.DateAdded,
            IsAnonymous = command.IsAnonymous
        });

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}