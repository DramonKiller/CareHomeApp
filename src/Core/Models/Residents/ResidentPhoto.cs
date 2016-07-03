namespace Dramonkiller.HappyGrandpaCareHome.Core.Models.Residents
{
    public class ResidentPhoto
    {
        public int Id { get; set; }

        public virtual Resident Resident { get; set; }

        public byte[] Photo { get; set; }
    }
}
