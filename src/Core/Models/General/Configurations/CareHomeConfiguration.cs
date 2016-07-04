using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Dramonkiller.CareHomeApp.Core.Models.General.Configurations
{
    internal class CareHomeConfiguration : EntityTypeConfiguration<CareHome>
    {
        public CareHomeConfiguration()
        {
            this.ToTable("CareHome");
            this.HasKey(x => x.Id);

            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name).IsRequired().HasMaxLength(100);
            this.Property(x => x.Logo).IsOptional();
        }
    }
}
