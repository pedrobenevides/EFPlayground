using System.Data.Entity.Migrations;
using System.Linq;
using EFStudy.Core.Entities;

namespace EFStudy.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyContext context)
        {
            if (context.Clients.Any()) return;

            InsertClients(1000, context);
        }

        private static void InsertClients(int numberOfClients, MyContext context)
        {
            for (var i = 0; i <= numberOfClients; i++)
            {
                context.Clients.Add(new Client { Name = $"Fulano {i}" });
            }
        }
    }
}
