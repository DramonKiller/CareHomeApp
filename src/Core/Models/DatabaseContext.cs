using Dramonkiller.HappyGrandpaCareHome.Core.Models.General;
using Dramonkiller.HappyGrandpaCareHome.Core.Models.General.Configurations;
using Dramonkiller.HappyGrandpaCareHome.Core.Models.Residents;
using Dramonkiller.HappyGrandpaCareHome.Core.Models.Residents.Configurations;
using System.Data.Entity;

namespace Dramonkiller.HappyGrandpaCareHome.Core.Models
{
    public class DatabaseContext : DbContext
    {
        static DatabaseContext()
        {
            Database.SetInitializer(new DatabaseContexInitializer());
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
            #region General

            modelBuilder.Configurations.Add(new ResidentConfiguration());

            #endregion

            #region Residents

            modelBuilder.Configurations.Add(new CareHomeConfiguration());

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
