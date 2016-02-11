using System;
using System.Collections.Generic;
using EFStudy.Core.Entities;
using EFStudy.Infra.Data;
using EFStudy.Infra.Data.Repositories;

namespace EFStudy.Output
{
    class Program
    {
        static void Main(string[] args)
        {
            var uow = new UnitOfWork(new MyContext());
            var clientRepository = new ClientRepository(uow);

            var cliente = new Client
            {
                Name = "Teste 1",
                Jobs = new List<Job> {new Job {Name = "Job do Cliente 1"}}
            };

            clientRepository.Create(cliente);
            uow.Dispose();
            Console.ReadKey();
        }
    }
}