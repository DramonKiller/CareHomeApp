using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Dramonkiller.HappyGrandpaCareHome.Core.Models.Residents.Configurations
{
    internal class ResidentConfiguration : EntityTypeConfiguration<Resident>
    {
        public ResidentConfiguration()
        {
            this.ToTable("Residents");
            this.HasKey(x => x.Id);


            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name).IsRequired().HasMaxLength(50);
            this.Property(x => x.Middle).IsOptional().HasMaxLength(50);
            this.Property(x => x.Surname).IsOptional().HasMaxLength(50);

            this.HasOptional(x => x.PhotoData).WithOptionalPrincipal(r => r.Resident).Map(m => m.MapKey("ResidentId"));
        }
    }
}
