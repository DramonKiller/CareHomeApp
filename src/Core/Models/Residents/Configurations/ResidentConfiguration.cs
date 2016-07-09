using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Dramonkiller.CareHomeApp.Core.Models.Residents.Configurations
{
    internal class ResidentConfiguration : EntityTypeConfiguration<Resident>
    {
        public ResidentConfiguration()
        {
            this.ToTable("Residents");
            this.HasKey(x => x.Id);


            this.Property(x => x.Id).HasColumnName("ResidentId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Code).HasColumnName("Code").IsOptional().HasMaxLength(10);
            this.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            this.Property(x => x.Middle).HasColumnName("Middle").IsOptional().HasMaxLength(50);
            this.Property(x => x.Surname).HasColumnName("Surname").IsOptional().HasMaxLength(50);
            this.Property(x => x.Birthdate).HasColumnName("Birthdate").IsOptional();
            this.Property(x => x.Age).HasColumnName("Age").IsOptional();

            this.HasOptional(x => x.PhotoData).WithOptionalPrincipal(r => r.Resident).Map(m => m.MapKey("ResidentId"));
        }
    }
}
