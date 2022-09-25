namespace FastEndpointTemplate.Domain.Test.Entities;

public class UserTest
{
    [Fact]
    public void Created_Constructor()
    {
        var user = new User();

        Assert.NotNull(user);
    }

    [Fact]
    public void Created_Init()
    {
        var guid = Guid.NewGuid();

        var user = new User
        {
            Id = guid,
            Name = "Test",
            Email = "test@test.com",
            Username = "test",
            Password = "test@123",
            Role = "test",
            CreatedAt = DateTime.Now,
            Active = true
        };

        Assert.NotNull(user);
        Assert.NotNull(user.CreatedAt);
        Assert.True(user.Active);
        Assert.Equal(guid, user.Id);
        Assert.Equal("Test", user.Name);
        Assert.Equal("test@test.com", user.Email);
        Assert.Equal("test", user.Username);
        Assert.Equal("test@123", user.Password);
        Assert.Equal("test", user.Role);
    }
}
