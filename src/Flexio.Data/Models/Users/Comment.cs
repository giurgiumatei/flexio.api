﻿using System;

namespace Flexio.Data.Models.Users
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsAnonymous { get; set; }
        public int AddedByUserId { get; set; }
        public int AddedToUserId { get; set; }

        public User AddedByUser { get; set; }
        public User AddedToUser { get; set; }
    }
}
