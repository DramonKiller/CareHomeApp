using Dramonkiller.CareHomeApp.DataAccess;
using Dramonkiller.CareHomeApp.DataAccess.Repositories;
using Dramonkiller.CareHomeApp.Domain.Entities.Residents;
using System;
using System.IO;
using System.Linq;
using System.Data.Entity; 

namespace Dramonkiller.CareHomeApp.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            //using (DatabaseContext context = new DatabaseContext())
            //{
            //    context.Residents.ToArray();

            //    Resident resident1 = new Resident
            //    {
            //        Code = "00001",
            //        Name = "Borja",
            //        Middle = "Món",
            //        Surname = "de York",
            //    };

            //    context.Residents.Add(resident1);

            //    Resident resident2 = new Resident
            //    {
            //        Code = "00002",
            //        Name = "Mirella",
            //        Middle = "Baila",
            //        Surname = "Sola",
            //    };

            //    context.Residents.Add(resident2);

            //    Resident resident3 = new Resident
            //    {
            //        Code = "00003",
            //        Name = "Hilaria",
            //        Middle = "Conejo",
            //        Surname = "Santo",
            //    };

            //    context.Residents.Add(resident3);

            //    Resident resident4 = new Resident
            //    {
            //        Code = "00004",
            //        Name = "Armando",
            //        Middle = "Bronca",
            //        Surname = "Segura",
            //    };

            //    context.Residents.Add(resident4);

            //    Resident resident5 = new Resident
            //    {
            //        Name = "Dolores",
            //        Middle = "Fuertes",
            //        Surname = "De Barriga",
            //    };

            //    context.SaveChanges();
            //}

            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.context.Database.Log = Console.Write;

                //var r1 = uow.Residents.GetAll().FirstOrDefault();
                //r1.ToString();

                //var r2 = uow.Residents.GetAll().Where(r => r.Code.Contains("3")).FirstOrDefault();
                //r2.ToString();

                uow.Residents.Count().ToString();

                uow.Residents.AllIncluding((r) => r.PhotoData).ToArray().ToString(); 

            }

        }
    }
}
