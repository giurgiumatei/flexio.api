using System;

namespace Flexio.API.Requests.Comments;

public class AddCommentRequest
{
    public string DisplayName { get; set; }
    public string Text { get; set; }
    public bool IsAnonymous { get; set; }
}