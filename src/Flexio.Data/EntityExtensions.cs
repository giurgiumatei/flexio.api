using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flexio.Data
{
    public static class EntityExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }

        public static IQueryable<T> GetPage<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var toSkip = pageSize * (page - 1);

            return query.Skip(toSkip).Take(pageSize);
        }
    }
}
