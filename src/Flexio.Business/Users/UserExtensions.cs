using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flexio.Business.Users.Models;
using Flexio.Data.Models.Users;
using Comment = Flexio.Business.Users.Models.Comment;

namespace Flexio.Business.Users
{
    public static class UserExtensions
    {
        public static IQueryable<UserFeedProfile> ToUserFeedProfiles(this IQueryable<User> query)
        {
            return query.Select(user => new UserFeedProfile
            {
                UserId = user.Id,
                DisplayName = user.UserDetail.FirstName + " " + user.UserDetail.LastName,
                City = user.UserDetail.City,
                Photo = user.UserDetail.ProfileImageUrl,
                LastComment = user.CommentsAddedToUser
                    .Select(c => new Comment
                    {
                        CommentId = c.Id,
                        DisplayName = GetDisplayName(c),
                        Text = c.Text,
                        DateAdded = c.DateAdded,
                        IsAnonymous = c.IsAnonymous
                    })
                    .OrderByDescending(comment => comment.DateAdded)
                    .FirstOrDefault()
            });
        }

        public static string GetDisplayName(Data.Models.Users.Comment comment)
        {
            if (comment.IsAnonymous)
            {
                return string.Empty;
            }

            return comment.AddedByUser.UserDetail.FirstName +
                   " " +
                   comment.AddedByUser.UserDetail.LastName;
        }
    }
}