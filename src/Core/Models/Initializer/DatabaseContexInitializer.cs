using Dramonkiller.HappyGrandpaCareHome.Core.Extensions;
using Dramonkiller.HappyGrandpaCareHome.Core.Models.General;
using Dramonkiller.HappyGrandpaCareHome.Core.Models.Residents;
using System.Data.Entity;

namespace Dramonkiller.HappyGrandpaCareHome.Core.Models.Initializer
{
    internal class DatabaseContexInitializer : 
        DropCreateDatabaseAlways<DatabaseContext> 
        //DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        private const int ImageSize = 100;

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
                Surname = "Ramírez",
                PhotoData = new ResidentPhoto { Photo = ImagesResource.RES0001.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident1);

            Resident resident2 = new Resident
            {
                Name = "María",
                Middle = "Martinez",
                Surname = "Sánchez",
                PhotoData = new ResidentPhoto { Photo = ImagesResource.RES0003.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident2);

            context.SaveChanges();
        }
    }
}
