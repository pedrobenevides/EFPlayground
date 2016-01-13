using System;
using System.Linq;
using EFStudy.Core.Entities;
using EFStudy.Infra.Data;
using EFStudy.Infra.Data.Configuration;
using EFStudy.Infra.Data.Repositories;
using ConsoleTables.Core;

namespace EFStudy.Output
{
    class Program
    {
        static void Main(string[] args)
        {

            var unitOfWork = new UnitOfWork<Client>(new MyContext());
            var clientRepository = new ClientRepository(unitOfWork);


            //unitOfWork.Commit();

            var clients = clientRepository.GetAll();
            var list = clients.ToList();
            var isInMemory = DBExtensions.IsQueryableInMemory(clients);

            var table = new ConsoleTable("Nome");

            foreach (var client in list)
            {
                table.AddRow(client.Name);
            }

            
            table.Write();
            Console.ReadKey();
        }
    }
}