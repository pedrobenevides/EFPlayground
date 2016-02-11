using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EFStudy.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<T> DbSet<T>() where T : class;
    }
}
