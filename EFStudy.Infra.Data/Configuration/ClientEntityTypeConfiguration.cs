using System.ComponentModel.DataAnnotations.Schema;
using EFStudy.Core.Entities;

namespace EFStudy.Infra.Data.Configuration
{
    public class ClientEntityTypeConfiguration : EntityTypeConfigurationBase<Client>
    {
        public ClientEntityTypeConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(x => x.Jobs).WithOptional(x => x.Client);
        }
    }
}