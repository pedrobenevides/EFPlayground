using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EFStudy.Core.Entities;
using EFStudy.Infra.Data.Interfaces;

namespace EFStudy.Infra.Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : Entity
    {
        private readonly MyContext context;
        
        public UnitOfWork(MyContext context)
        {
            this.context = context;
        }
        
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public DbEntityEntry<T> Entry(T entity)
        {
            return context.Entry(entity);
        }

        public DbSet<T> DbSet => context.Set<T>();
    }
}