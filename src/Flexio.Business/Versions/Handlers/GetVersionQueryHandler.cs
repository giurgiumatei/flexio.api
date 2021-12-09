using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flexio.Business.Versions.Models;
using Flexio.Business.Versions.Queries;
using Flexio.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flexio.Business.Versions.Handlers
{
    public class GetVersionQueryHandler : IRequestHandler<GetVersionQuery, VersionCode>
    {
        private readonly FlexioContext _context;

        public GetVersionQueryHandler(FlexioContext context)
        {
            _context = context;
        }

        public async Task<VersionCode> Handle(GetVersionQuery request, CancellationToken cancellationToken)
        {
            return await _context.ApplicationVersions
                .Where(v => v.Name == request.Name)
                .ToVersionCode()
                .FirstOrDefaultAsync();
        }
    }
}
