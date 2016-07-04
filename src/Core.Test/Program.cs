using Dramonkiller.CareHomeApp.Core.Models;
using System;
using System.IO;
using System.Linq;

namespace Dramonkiller.CareHomeApp.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            using (DatabaseContext dc = new DatabaseContext())
            {
                dc.Residents.ToArray();
            }
        }
    }
}
