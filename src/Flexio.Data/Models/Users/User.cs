using System;
using System.Collections.Generic;
using Flexio.Data.Models.Comments;

namespace Flexio.Data.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime DateAdded { get; set; }

        public UserDetail UserDetail { get; set; }
        public List<Comment> CommentsAddedByUser { get; set; }
        public List<Comment> CommentsAddedToUser { get; set; }
    }
}
