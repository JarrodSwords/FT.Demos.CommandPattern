using System;
using FT.Demos.CommandPattern.Domain;
using FT.Demos.CommandPattern.Domain.Personnel;
using FT.Demos.CommandPattern.Services;

namespace FT.Demos.CommandPattern.BasicImplementations
{
    public class PersonConfigurationService : IPersonConfigurationService
    {
        private readonly IPersonRepository _repository;

        public PersonConfigurationService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public void Activate(int id)
        {
            var person = _repository.Get(id);
            person.Status = Status.Active;
            _repository.Update(person);
        }

        public void Create(Person person)
        {
            _repository.Create(person);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
