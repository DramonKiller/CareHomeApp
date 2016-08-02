using Dramonkiller.CareHomeApp.WebClient.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dramonkiller.CareHomeApp.WebClient.ViewModels
{
    public class ResidentViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(Code), ResourceType = typeof(Resources))]
        public string Code { get; set; }

        [Display(Name = nameof(Name), ResourceType = typeof(Resources))]
        public string Name { get; set; }

        [Display(Name = nameof(Middle), ResourceType = typeof(Resources))]
        public string Middle { get; set; }

        [Display(Name = nameof(Surname), ResourceType = typeof(Resources))]
        public string Surname { get; set; }

        [Display(Name = nameof(FullName), ResourceType = typeof(Resources))]
        public string FullName { get; set; }

        public string DocumentId { get; set; }

        [Display(Name = nameof(Birthdate), ResourceType = typeof(Resources))]
        public DateTime? Birthdate { get; set; }

        [Display(Name = nameof(Age), ResourceType = typeof(Resources))]
        public int? Age { get; set; }

        //public GenderDTO? Gender { get; set; }

        [Display(Name = nameof(Notifications), ResourceType = typeof(Resources))]
        public string Notifications { get; set; }

        public bool HasNotifications { get; set; }

        public string Comments { get; set; }
    }
}