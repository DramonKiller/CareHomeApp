using Dramonkiller.CareHomeApp.DataAccess;
using Dramonkiller.CareHomeApp.Domain.Entities.Residents;
using Dramonkiller.CareHomeApp.Domain.Models.General;
using Dramonkiller.CareHomeApp.Extensions;
using Dramonkiller.CareHomeApp.WebServer.TestData;
using System.Data.Entity;
using System.Linq;

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
                DocumentId = "12345678Z",
                Notifications = "He is diabetic",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0002.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident1);

            Resident resident2 = new Resident
            {
                Code = "00002",
                Name = "Mirella",
                Middle = "Baila",
                Surname = "Sola",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0003.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident2);

            Resident resident3 = new Resident
            {
                Code = "00003",
                Name = "Hilaria",
                Middle = "Conejo",
                Surname = "Santo",
                DocumentId = "z2222222x",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0001.Resize(ImageSize, ImageSize).ToByteArray() }
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
                Notifications = "He is diabetic",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0004.Resize(ImageSize, ImageSize).ToByteArray() }
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
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0005.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident8);

            Resident resident9 = new Resident
            {
                Code = "00009",
                Name = "Sonia",
                Middle = "Vieja",
                Surname = "Alegre",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0007.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident9);

            Resident resident10 = new Resident
            {
                Code = "00010",
                Name = "Francisco",
                Middle = "Lorinco",
                Surname = "Lorado",
                DocumentId = "v3232323232x",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0006.Resize(ImageSize, ImageSize).ToByteArray() }
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
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0008.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident12);

            Resident resident13 = new Resident
            {
                Code = "00013",
                Name = "Domingo",
                Middle = "Díaz",
                Surname = "Festivo",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0010.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident13);

            Resident resident14 = new Resident
            {
                Code = "00014",
                Name = "Eva",
                Middle = "Fina",
                Surname = "Segura",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0009.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident14);

            Resident resident15 = new Resident
            {
                Code = "00015",
                Name = "José Luis",
                Middle = "Lamata",
                Surname = "Feliz",
                DocumentId = "xxxxxx",
                Notifications = "He is diabetic",
            };

            context.Residents.Add(resident15);

            Resident resident16 = new Resident
            {
                Code = "00016",
                Name = "Margarito",
                Middle = "Flores",
                Surname = "del Campo",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0011.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident16);

            Resident resident17 = new Resident
            {
                Code = "00017",
                Name = "Estrella",
                Middle = "de la Osa",
                Surname = "Mayor",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0012.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident17);

            Resident resident18 = new Resident
            {
                Code = "00018",
                Name = "Elena",
                Middle = "Nito",
                Surname = "del Bosque",
            };

            context.Residents.Add(resident18);

            Resident resident19 = new Resident
            {
                Code = "00019",
                Name = "María Concepción",
                Middle = "Culo",
                Surname = "Bonito",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0016.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident19);

            Resident resident20 = new Resident
            {
                Code = "00020",
                Name = "Ramona",
                Middle = "Ponte",
                Surname = "Alegre",
                DocumentId = "34er4r4",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0014.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident20);

            Resident resident21 = new Resident
            {
                Code = "00021",
                Name = "Antonio",
                Middle = "Suelta",
                Surname = "Melo",
                Notifications = "aaaa aaaaaa a aaaaa",
                PhotoData = new ResidentPhoto { Photo = ImageResources.RES0015.Resize(ImageSize, ImageSize).ToByteArray() }
            };

            context.Residents.Add(resident21);

            Resident resident22 = new Resident
            {
                Code = "00022",
                Name = "Pedro",
                Middle = "Trabajo",
                Surname = "Cumplido",
            };

            context.Residents.Add(resident22);

            Resident resident23 = new Resident
            {
                Code = "00023",
                Name = "Fernando",
                Middle = "Coco",
                Surname = "Cuadrado",
                Notifications = "blablabla",
            };

            context.Residents.Add(resident23);

            context.Residents.Local.ToList().ForEach(r => r.UpdateFullName()); 

            context.SaveChanges();
        }
    }
}
