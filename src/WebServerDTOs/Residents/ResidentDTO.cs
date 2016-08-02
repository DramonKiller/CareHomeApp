using System;

namespace Dramonkiller.CareHomeApp.WebServerDTOs.Residents
{
    public class ResidentDTO : ResidentLiteDTO 
    {
        public DateTime? Birthdate { get; set; }

        public int? Age { get; set; }

        public GenderDTO? Gender { get; set; }

        public string Comments { get; set; }
    }
}
