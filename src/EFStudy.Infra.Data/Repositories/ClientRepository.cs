using System.Data.Entity;
using System.Linq;
using EFStudy.Core.Entities;
using EFStudy.Infra.Data.Interfaces;

namespace EFStudy.Infra.Data.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly IUnitOfWork<Client> context;
        private readonly IDbSet<Client> clients;

        public ClientRepository(IUnitOfWork<Client> context) : base(context)
        {
            this.context = context;
            clients = context.DbSet;
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