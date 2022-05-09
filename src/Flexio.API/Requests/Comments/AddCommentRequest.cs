using System;

namespace Flexio.API.Requests.Comments;

public class AddCommentRequest
{
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public string Text { get; set; }
    public int AddedToUserId { get; set; }
    public bool IsAnonymous { get; set; }
}