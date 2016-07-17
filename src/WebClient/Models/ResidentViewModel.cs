using Dramonkiller.CareHomeApp.WebClient.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dramonkiller.CareHomeApp.WebClient.Models
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

        [Display(Name = nameof(Birthdate), ResourceType = typeof(Resources))]
        public DateTime? Birthdate { get; set; }

        [Display(Name = nameof(Age), ResourceType = typeof(Resources))]
        public int? Age { get; set; }

        public void RefreshFullName()
        {
            FullName = string.Format("{0} {1} {2}", Name, Middle, Surname).Trim();
        }
    }
}