using System;
using System.Collections.Generic;
using System.Data.Entity;
using EFStudy.Core.Entities;
using EFStudy.Infra.Data;
using EFStudy.Infra.Data.Interfaces;
using EFStudy.Infra.Data.Repositories;

namespace EFStudy.Output
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());

            var uow = new UnitOfWork(new MyContext());
            var clientRepository = new ClientRepository(uow);

            CriarCliente(clientRepository);

            uow.Dispose();
            Console.ReadKey();
        }

        static void CriarCliente(IClientRepository clientRepository)
        {
            var cliente = new Client
            {
                Name = "Teste 1",
                Jobs = new List<Job> { new Job { Name = "Job do Cliente 1" } }
            };

            clientRepository.Create(cliente);
        }

        static void AutalizarCliente(IClientRepository clientRepository, int id)
        {
            var client = clientRepository.GetById(id);
            client.Name = "Atualizado";

            clientRepository.Update(client);
        }
    }
}