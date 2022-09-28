namespace FastEndpointTemplate.Persistence.Test.Repositories;

public class UserRepositoryTest
{
    private readonly IUserRepository _repository;

    public UserRepositoryTest()
    {
        var context = ContextUtil.GetContext();
        _repository = new UserRepository(context);
    }

    [Theory]
    [InlineData("admin", "admin@123", true)]
    [InlineData("admin", "admin", false)]
    public async Task IsUserValid_Validation(string username, string password, bool valid)
    {
        var result = await _repository.IsUserValidAsync(username, password);
        if (valid)
            Assert.True(result);
        else
            Assert.False(result);
    }
}
