using FastEndpointTemplate.Domain.Entities;
using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FastEndpointTemplate.Persistence.Repositories;

public class UserRepository(ApplicationContext context)
    : BaseRepository<User>(context), IUserRepository
{
    public Task<bool> IsUserValidAsync(string username, string password, CancellationToken cancellationToken)
    {
        return Context.Users
            .Where(x => x.Username == username)
            .Where(x => x.Password == password)
            .AnyAsync(cancellationToken);
    }
}
