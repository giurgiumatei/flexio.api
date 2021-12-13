using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flexio.Azure.Graph.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Flexio.Azure.Graph.Services
{
    public class GraphUserManager: BaseGraphServiceClient, IGraphUserManager
    {
        public GraphUserManager(ILogger<GraphUserManager> logger, IOptions<FlexioAzureGraphConfiguration> options) : base(logger, options)
        {
        }
    }
}
