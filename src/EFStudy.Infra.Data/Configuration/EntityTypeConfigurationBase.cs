using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EFStudy.Core.Entities;

namespace EFStudy.Infra.Data.Configuration
{
    public class EntityTypeConfigurationBase<T> : EntityTypeConfiguration<T> where T : Entity
    {
        public EntityTypeConfigurationBase()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.TimeStamp).IsRowVersion().IsConcurrencyToken(true);
        }
    }
}
