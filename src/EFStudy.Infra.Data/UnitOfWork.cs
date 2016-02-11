using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EFStudy.Infra.Data.Interfaces;

namespace EFStudy.Infra.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyContext _context;
        private DbContextTransaction _transaction;
        private bool _isToRollBack;

        public UnitOfWork(MyContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _transaction ?? _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_isToRollBack) return;

            _context.SaveChanges();
        }

        public void Rollback()
        {
            _isToRollBack = true;
            _transaction.Rollback();
        }

        public DbEntityEntry<T> Entry<T>(T entity) where T : class => _context.Entry(entity);

        public DbSet<T> DbSet<T>() where T : class => _context.Set<T>();

        public void Dispose()
        {
            if (!_isToRollBack)
                Commit();

            GC.SuppressFinalize(this);
        }
    }
}