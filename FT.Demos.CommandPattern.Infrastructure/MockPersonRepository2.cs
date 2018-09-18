using System.Collections.Generic;
using System.Linq;
using FT.Demos.CommandPattern.Domain.Personnel;

namespace FT.Demos.CommandPattern.Infrastructure
{
    public class MockPersonRepository2 : IPersonRepository
    {
        private readonly List<Person> _deletedPeople;
        private readonly List<Person> _people;

        public MockPersonRepository2()
        {
            _deletedPeople = new List<Person>();
            _people = new List<Person>();
        }

        public int Create(Person person)
        {
            person.Id = _people.Count > 0
                ? _people.Max(x => x.Id) + 1
                : 0;

            _people.Add(person);

            return person.Id;
        }

        public void Delete(int id)
        {
            var person = _people.Find(x => x.Id == id);
            _people.RemoveAt(_people.IndexOf(person));
            _deletedPeople.Add(person);
        }

        public Person Get(int id)
        {
            return DeepCopy(_people.Find(x => x.Id == id));
        }

        public ICollection<Person> GetAll()
        {
            return _people;
        }

        public ICollection<Person> GetAllDeleted()
        {
            return _deletedPeople;
        }

        public void Update(Person person)
        {
            var storedPerson = _people.Find(x => x.Id == person.Id);

            storedPerson.Name = person.Name;
            storedPerson.Surname = person.Surname;
            storedPerson.Status = person.Status;
        }

        /// <summary>
        /// pseudo deep copy
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        private static Person DeepCopy(Person person)
        {
            return new Person
                   {
                       Id = person.Id,
                       Name = person.Name,
                       Surname = person.Surname,
                       Status = person.Status
                   };
        }
    }
}
