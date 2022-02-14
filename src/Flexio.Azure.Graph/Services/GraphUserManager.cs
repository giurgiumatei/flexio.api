using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flexio.Azure.Graph.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph;

namespace Flexio.Azure.Graph.Services
{
    public class GraphUserManager: BaseGraphServiceClient, IGraphUserManager
    {
        private ILogger<GraphUserManager> _logger;

        public GraphUserManager(ILogger<GraphUserManager> logger, IOptions<FlexioAzureGraphConfiguration> options) : base(logger, options)
        {
        }

        public async void AddUser(string email)
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
                        IssuerAssignedId = email
                    }
                },
                PasswordProfile = new PasswordProfile
                {
                    ForceChangePasswordNextSignIn = false,
                    Password = "Test123" // create a password generator
                }
            };

            try
            {
                var userAdded = await _graphClient.Users.Request().AddAsync(graphUser);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"There was an error while adding a user with email {email} in Azure AD");
            }
        }
    }
}
