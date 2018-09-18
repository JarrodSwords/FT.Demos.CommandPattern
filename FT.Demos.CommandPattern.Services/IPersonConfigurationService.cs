using FT.Demos.CommandPattern.Domain.Personnel;

namespace FT.Demos.CommandPattern.Services
{
    public interface IPersonConfigurationService
    {
        void Activate(int id);
        void Create(Person person);
        void Delete(int id);
        Person Get(int id);
    }
}
