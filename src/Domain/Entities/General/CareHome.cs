using Dramonkiller.CareHomeApp.Domain.Entities;

namespace Dramonkiller.CareHomeApp.Domain.Models.General
{
    public class CareHome : IEntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Logo { get; set; }
    }
}
