using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Business.Comments.Commands;
using Flexio.Data;
using Flexio.Data.Models.Comments;
using MediatR;

namespace Flexio.Business.Comments.Handlers;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, bool>
{
    private readonly FlexioContext _context;

    public AddCommentCommandHandler(FlexioContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(AddCommentCommand command, CancellationToken cancellationToken)
    {
        _context.Comments.Add(new Comment
        {
            Text = command.Text,
            AddedByUserId = GetAddedByUserIdByEmail(command.Email),
            AddedToUserId = command.AddedToUserId,
            DateAdded = command.DateAdded,
            IsAnonymous = command.IsAnonymous
        });

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public int GetAddedByUserIdByEmail(string email)
    {
        return _context.Users
            .FirstOrDefault(user => user.Email == email)!.Id;
    }
}