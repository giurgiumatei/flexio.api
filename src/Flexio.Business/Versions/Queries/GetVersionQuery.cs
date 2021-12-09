using Flexio.Business.Versions.Models;
using MediatR;

namespace Flexio.Business.Versions.Queries
{
    public class GetVersionQuery : IRequest<VersionCode>
    {
        public string Name { get; set; }
    }
}
