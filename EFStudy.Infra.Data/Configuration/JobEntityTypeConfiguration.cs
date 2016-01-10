using EFStudy.Core.Entities;

namespace EFStudy.Infra.Data.Configuration
{
    public class JobEntityTypeConfiguration : EntityTypeConfigurationBase<Job>
    {
        public JobEntityTypeConfiguration()
        {
            HasOptional(x => x.Client).WithMany(x => x.Jobs);
        }
    }
}