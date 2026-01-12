namespace TheaterBackend.Application.Services;

using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;

public class PersonService : GenericService<Person>
{

    public PersonService(IPersonRepo repo) : base(repo)
    {
    }


}
