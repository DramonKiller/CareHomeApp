using Dramonkiller.HappyGrandpaCareHome.Core.Models.General;
using Dramonkiller.HappyGrandpaCareHome.Core.Models.Residents;
using System.Data.Entity;

namespace Dramonkiller.HappyGrandpaCareHome.Core.Models
{
    internal class DatabaseContexInitializer : 
        DropCreateDatabaseAlways<DatabaseContext> 
        //DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            CareHome careHome = new CareHome
            {
                Name = "My care home"
            };

            context.CareHomes.Add(careHome);

            Resident resident1 = new Resident
            {
                Name = "Pepe",
                Middle = "Pérez",
                Surname = "Ramírez"
            };

            context.Residents.Add(resident1);

            Resident resident2 = new Resident
            {
                Name = "María",
                Middle = "Martinez",
                Surname = "Sánchez"
            };

            context.Residents.Add(resident2);

            context.SaveChanges();
        }
    }
}
