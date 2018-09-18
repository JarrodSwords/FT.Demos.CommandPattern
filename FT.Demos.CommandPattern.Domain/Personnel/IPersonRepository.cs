using System.Collections.Generic;

namespace FT.Demos.CommandPattern.Domain.Personnel
{
    /// <summary>
    /// Receiver
    /// </summary>
    public interface IPersonRepository
    {
        int Create(Person person);
        void Delete(int id);
        Person Get(int id);
        ICollection<Person> GetAll();
        ICollection<Person> GetAllDeleted();
        void Update(Person person);
    }
}
