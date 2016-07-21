using System;

namespace Dramonkiller.CareHomeApp.WebServerDTOs.Residents
{
    public class ResidentDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Middle { get; set; }

        public string Surname { get; set; }

        public string FullName { get; set; }

        public DateTime? Birthdate { get; set; }

        public int? Age { get; set; }
    }
}
