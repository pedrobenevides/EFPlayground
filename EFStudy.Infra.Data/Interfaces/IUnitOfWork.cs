using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EFStudy.Core.Entities;

namespace EFStudy.Infra.Data.Interfaces
{
    public interface IUnitOfWork<T> where T : Entity
    {
        void BeginTransaction();
        void Commit();
        DbEntityEntry<T> Entry(T entity);

        DbSet<T> DbSet { get; }
    }
}
