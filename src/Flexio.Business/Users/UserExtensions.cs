using System;
using System.Linq;
using Flexio.Business.Users.Models;
using Flexio.Data.Models.Users;
using Comment = Flexio.Business.Users.Models.Comment;

namespace Flexio.Business.Users;

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

    public static UserProfile ToUserProfile(this User user)
    {
        return new UserProfile
        {
            UserId = user.Id,
            DisplayName = user.UserDetail.DisplayName,
            City = user.UserDetail.City,
            Country = user.UserDetail.Country,
            Gender = Enum.GetName(typeof(Gender), user.UserDetail.GenderId),
            Photo = user.UserDetail.ProfileImageUrl,
            Comments = user.CommentsAddedToUser
                .Select(c => new Comment
                {
                    CommentId = c.Id,
                    DisplayName = GetDisplayName(c),
                    Text = c.Text,
                    DateAdded = c.DateAdded,
                    IsAnonymous = c.IsAnonymous
                })
                .ToList()
        };
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