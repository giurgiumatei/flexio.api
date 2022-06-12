using System;

namespace Flexio.Business.Comments.Models;

public record Comment
{
    public int CommentId { get; set; }
    public string DisplayName { get; set; }
    public string Text { get; set; }
    public DateTime DateAdded { get; set; }
    public bool IsAnonymous { get; set; }
    public bool CanBeDeleted { get; set; }
}