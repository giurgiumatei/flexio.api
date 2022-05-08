using System;
using MediatR;

namespace Flexio.Business.Comments.Commands
{
    public class AddCommentCommand : IRequest<bool>
    {
        public string DisplayName { get; set; }
        public string Text { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime DateAdded { get; set; }
    }
}