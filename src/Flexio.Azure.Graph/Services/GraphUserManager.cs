using System;
using System.Collections.Generic;
using Flexio.Azure.Graph.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph;

namespace Flexio.Azure.Graph.Services;

public class GraphUserManager: BaseGraphServiceClient, IGraphUserManager
{
    private ILogger<GraphUserManager> _logger;

    public GraphUserManager(ILogger<GraphUserManager> logger, IOptions<FlexioAzureGraphConfiguration> options) : base(logger, options)
    {
        _logger = logger;
    }

    public async void AddUser(Data.Models.Users.User user, string password)
    {
        var graphUser = new User
        {
            AccountEnabled = true,
            Identities = new List<ObjectIdentity>
            {
                new ObjectIdentity
                {
                    SignInType = "emailAddress",
                    Issuer = _identityIssuer,
                    IssuerAssignedId = user.Email
                }
            },
            PasswordProfile = new PasswordProfile
            {
                ForceChangePasswordNextSignIn = false,
                Password = password
            },
            GivenName = user.UserDetail.LastName,
            Surname = user.UserDetail.FirstName,
            DisplayName = user.UserDetail.DisplayName,
            City = user.UserDetail.City,
            Country = user.UserDetail.Country
        };

        try
        {
            await _graphClient.Users.Request().AddAsync(graphUser);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"There was an error while adding a user with email {user.Email} in Azure AD");
        }
    }
}