using Dramonkiller.CareHomeApp.DataAccess.Configurations.General;
using Dramonkiller.CareHomeApp.DataAccess.Configurations.Residents;
using Dramonkiller.CareHomeApp.Domain.Entities.Residents;
using Dramonkiller.CareHomeApp.Domain.Models.General;
using System.Data.Entity;

namespace Dramonkiller.CareHomeApp.DataAccess
{
    public class DatabaseContext : DbContext
    {
        static DatabaseContext()
        {
            //Database.SetInitializer(new DatabaseContexInitializer());
        }

        public DatabaseContext() 
            : base(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDBFilename=|DataDirectory|\Database.mdf")
        {
        }

        #region Collections

        #region General

        public IDbSet<CareHome> CareHomes { get; set; }

        #endregion

        #region Residents

        public IDbSet<Resident> Residents { get; set; }

        #endregion

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Residents

            modelBuilder.Configurations.Add(new ResidentConfiguration());
            modelBuilder.Configurations.Add(new ResidentPhotoConfiguration());

            #endregion

            #region General

            modelBuilder.Configurations.Add(new CareHomeConfiguration());

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
