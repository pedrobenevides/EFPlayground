using EFStudy.Core.Entities;
using EFStudy.Infra.Data;
using EFStudy.Infra.Data.Repositories;

namespace EFStudy.Output
{
    class Program
    {
        static void Main(string[] args)
        {
            var unitOfWork = new UnitOfWork<Client>(new MyContext());
            var clientRepository = new ClientRepository(unitOfWork);

            var client = new Client
            {
                Name = "Nova Arquitetura"
            };

            clientRepository.Create(client);
            unitOfWork.Commit();
        }
    }
}