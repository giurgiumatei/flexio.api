using System;
using Microsoft.Graph;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;


namespace Flexio.Azure.Graph.Configuration
{
    public class BaseGraphServiceClient
    {
        protected readonly GraphServiceClient _graphClient;
        protected readonly string _identityIssuer;
        private readonly ILogger _logger;

        public BaseGraphServiceClient(ILogger logger, IOptions<FlexioAzureGraphConfiguration> options)
        {
            _logger = logger;
            _graphClient = CreateGraphClient(options);
            _identityIssuer = options.Value.IdentityIssuer;
        }

        private GraphServiceClient CreateGraphClient(IOptions<FlexioAzureGraphConfiguration> options)
        {
            try
            {
                var confidentialClientApplication = ConfidentialClientApplicationBuilder
                    .Create(options.Value.ApplicationId)
                    .WithTenantId(options.Value.DirectoryId)
                    .WithClientSecret(options.Value.ClientSecret)
                    .Build();

                var authProvider = new ClientCredentialProvider(confidentialClientApplication);
                return new GraphServiceClient(authProvider);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "There was an error while trying to create the GraphServiceClient.");
                throw;
            }
        }
    }
}
