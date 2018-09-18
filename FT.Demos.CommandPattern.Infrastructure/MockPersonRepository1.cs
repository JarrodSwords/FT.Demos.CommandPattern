using System.Collections.Generic;
using System.Linq;
using FT.Demos.CommandPattern.Domain;
using FT.Demos.CommandPattern.Domain.Personnel;

namespace FT.Demos.CommandPattern.Infrastructure
{
    public class PR1 : IPersonRepository
    {
        public int Create(Person person)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Person Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Person> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Person> GetAllDeleted()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new System.NotImplementedException();
        }
    }

    public class PR2 : IPersonRepository, IRestorable
    {
        public int Create(Person person)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Person Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Person> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Person> GetAllDeleted()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new System.NotImplementedException();
        }

        public void Undelete(int id)
        {
            throw new System.NotImplementedException();
        }
    }

    public class MockPersonRepository1 : IPersonRepository
    {
        private readonly List<Person> _people;

        public MockPersonRepository1()
        {
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
            var person = Get(id);
            person.Status = Status.Deleted;
            Update(person);
        }

        public Person Get(int id)
        {
            return DeepCopy(_people.Find(x => x.Id == id));
        }

        public ICollection<Person> GetAll()
        {
            return _people
                .Where(x => x.Status != Status.Deleted)
                .ToList();
        }

        public ICollection<Person> GetAllDeleted()
        {
            return _people
                .Where(x => x.Status == Status.Deleted)
                .ToList();
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
