namespace Dramonkiller.HappyGrandpaCareHome.Core.Models.Residents
{
    public class Resident
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Middle { get; set; }

        public string Surname { get; set; }

        public virtual ResidentPhoto PhotoData { get; set; }
    }
}
