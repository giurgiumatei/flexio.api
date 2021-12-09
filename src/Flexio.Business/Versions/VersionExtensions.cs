using Flexio.Business.Versions.Models;
using System.Linq;
using Flexio.Data.Models.ApplicationVersions;

namespace Flexio.Business.Versions
{
    public static class VersionExtensions
    {
        public static IQueryable<VersionCode> ToVersionCode(this IQueryable<ApplicationVersion> query)
        {
            return query.Select(q => new VersionCode
            {
                Version = q.Version
            });
        }
    }
}
