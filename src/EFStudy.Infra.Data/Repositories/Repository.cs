using System;
using System.Data.Entity;
using EFStudy.Core.Entities;
using EFStudy.Core.Interfaces.Repositories;
using EFStudy.Infra.Data.Interfaces;

namespace EFStudy.Infra.Data.Repositories
{
    public class Repository<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IDbSet<T> dbSet; 

        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            dbSet = unitOfWork.DbSet<T>();
        }

        public T Create(T entity)
        {
            return dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            unitOfWork.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);

            if(entity == null)
                throw new Exception($"There is no entity with this id {id}");

            dbSet.Remove(entity);
        }
    }
}
