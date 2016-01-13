using System.Data.Entity.Infrastructure;
using System.Linq;

namespace EFStudy.Infra.Data.Configuration
{
    public static class DBExtensions
    {
        public static bool IsQueryableInMemory(IQueryable query) => !(query.Provider is IDbAsyncQueryProvider);
    }
}
