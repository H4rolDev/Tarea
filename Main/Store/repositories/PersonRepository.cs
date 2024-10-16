using Main.services;
using Main.repositories;

namespace Main.Store.repositories
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private readonly IPersonService _person;
        public PersonRepositoryImpl(
            IPersonService person
        )
        {
            _person = person;
        }
        public IPersonService person()
        {
            return _person;
        }
    }
}