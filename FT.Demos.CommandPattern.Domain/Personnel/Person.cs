namespace FT.Demos.CommandPattern.Domain.Personnel
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Status Status { get; set; }

        public override string ToString()
        {
            return $"Id: {Id};\tName: {Surname}, {Name};\tStatus: {Status}";
        }
    }
}
