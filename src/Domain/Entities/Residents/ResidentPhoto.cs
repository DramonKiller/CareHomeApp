namespace Dramonkiller.CareHomeApp.Domain.Entities.Residents
{
    public class ResidentPhoto
    {
        public int Id { get; set; }

        public virtual Resident Resident { get; set; }

        public byte[] Photo { get; set; }
    }
}
