using Dramonkiller.CareHomeApp.Domain.Entities.Residents;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Dramonkiller.CareHomeApp.DataAccess.Configurations.Residents
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
            this.Property(x => x.FullName).HasColumnName("FullName").IsOptional().HasMaxLength(160);
            this.Property(x => x.Birthdate).HasColumnName("Birthdate").IsOptional();
            this.Property(x => x.Age).HasColumnName("Age").IsOptional();
            this.Property(x => x.Notifications).HasColumnName("Notifications").IsOptional().HasMaxLength(250);
            this.Property(x => x.Gender).HasColumnName("Gender").IsOptional();
            this.Property(x => x.DocumentId).HasColumnName("DocumentId").IsOptional().HasMaxLength(20);
            this.Property(x => x.Comments).HasColumnName("Comments").IsOptional().HasMaxLength(4000);

            this.HasOptional(x => x.PhotoData).WithOptionalPrincipal(r => r.Resident).Map(m => m.MapKey("ResidentId"));
        }
    }
}
