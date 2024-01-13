using FastEndpointTemplate.Domain.Entities;

namespace FastEndpointTemplate.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> IsUserValidAsync(string username, string password, CancellationToken cancellationToken);
}
