using System;
using Flexio.Data.Models.Users;
using Microsoft.AspNetCore.Http;

namespace Flexio.API.Requests.Users;

public class AddUserProfileRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public Gender GenderId { get; set; }
    public IFormFile ProfileImage { get; set; }
}