namespace EFStudy.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        T Create(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);
    }
}
