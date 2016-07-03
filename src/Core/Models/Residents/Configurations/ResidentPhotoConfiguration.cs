using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Dramonkiller.HappyGrandpaCareHome.Core.Models.Residents.Configurations
{
    public class ResidentPhotoConfiguration : EntityTypeConfiguration<ResidentPhoto>
    {
        public ResidentPhotoConfiguration()
        {
            this.ToTable("ResidentPhotos");
            this.HasKey(x => x.Id);


            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Photo).IsRequired();
            
        }
    }
}
