using System.Data.Entity;
using System.Linq;
using EFStudy.Core.Entities;
using EFStudy.Infra.Data.Interfaces;

namespace EFStudy.Infra.Data.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Client> clients;

        public ClientRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            clients = unitOfWork.DbSet<Client>();
        }

        public Client GetByIdAsNoTracking(int id)
        {
            return clients.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Client> GetAll()
        {
            return clients;
        }
    }
}