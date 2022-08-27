using FastEndpointTemplate.Domain.Entities;
using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FastEndpointTemplate.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationContext context) : base(context)
    {
    }


    public Task<bool> IsUserValidAsync(string username, string password)
    {
        return Context.Users.AnyAsync(x => x.Username == username && x.Password == password);
    }
}