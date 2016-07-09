using Dramonkiller.CareHomeApp.Core.Extensions;
using Dramonkiller.CareHomeApp.Core.Models.General;
using Dramonkiller.CareHomeApp.Core.Models.Residents;
using System.Data.Entity;

namespace Dramonkiller.CareHomeApp.Core.Models.Initializer
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
                Code = "00001",
                Name = "Borja",
                Middle = "Món",
                Surname = "de York",
                PhotoData = new ResidentPhoto { Photo = ImagesResource.RES0002.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident1);

            Resident resident2 = new Resident
            {
                Code = "00002",
                Name = "Mirella",
                Middle = "Baila",
                Surname = "Sola",
                PhotoData = new ResidentPhoto { Photo = ImagesResource.RES0003.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident2);

            Resident resident3 = new Resident
            {
                Code = "00003",
                Name = "Hilaria",
                Middle = "Conejo",
                Surname = "Santo",
                PhotoData = new ResidentPhoto { Photo = ImagesResource.RES0001.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident3);

            Resident resident4 = new Resident
            {
                Code = "00004",
                Name = "Armando",
                Middle = "Bronca",
                Surname = "Segura",
            };

            context.Residents.Add(resident4);

            Resident resident5 = new Resident
            {
                Name = "Dolores",
                Middle = "Fuertes",
                Surname = "De Barriga",
            };

            context.Residents.Add(resident5);

            Resident resident6 = new Resident
            {
                Code = "00006",
                Name = "Pere",
                Middle = "Gil",
                Surname = "Gil",
                PhotoData = new ResidentPhoto { Photo = ImagesResource.RES0004.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident6);

            Resident resident7 = new Resident
            {
                Code = "00007",
                Name = "Ana",
                Middle = "Mier",
                Surname = "de Cilla",
            };

            context.Residents.Add(resident7);

            Resident resident8 = new Resident
            {
                Code = "00008",
                Name = "Tomás",
                Middle = "Al-vino",
                Surname = "Blanco",
                PhotoData = new ResidentPhoto { Photo = ImagesResource.RES0005.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident8);

            Resident resident9 = new Resident
            {
                Code = "00009",
                Name = "Sonia",
                Middle = "Vieja",
                Surname = "Alegre",
                PhotoData = new ResidentPhoto { Photo = ImagesResource.RES0007.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident9);

            Resident resident10 = new Resident
            {
                Code = "00010",
                Name = "Francisco",
                Middle = "Lorinco",
                Surname = "Lorado",
                PhotoData = new ResidentPhoto { Photo = ImagesResource.RES0006.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident10);

            Resident resident11 = new Resident
            {
                Code = "00011",
                Name = "MariPaz Descanse",
                Middle = "Enella",
                Surname = "Misma",
            };

            context.Residents.Add(resident11);

            Resident resident12 = new Resident
            {
                Code = "00012",
                Name = "Daniel",
                Middle = "De La Granja",
                Surname = "San Francisco",
                PhotoData = new ResidentPhoto { Photo = ImagesResource.RES0008.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident12);

            context.SaveChanges();
        }
    }
}
