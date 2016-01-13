using System.Linq;
using EFStudy.Core.Entities;
using EFStudy.Core.Interfaces.Repositories;

namespace EFStudy.Infra.Data.Interfaces
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        Client GetByIdAsNoTracking(int id);
        IQueryable<Client> GetAll();
    }
}