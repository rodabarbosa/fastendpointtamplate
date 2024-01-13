namespace FastEndpointTemplate.Domain.Test.Entities;

public class UserTest
{
    [Fact]
    public void Created_Constructor()
    {
        var user = new User();

        Assert.NotNull(user);
    }

    [Theory]
    [InlineData("E9747EC6-5F1C-44AD-8973-394C09DA1800", "Test", "test@test.com", "test", "test@123", "test", "2023-10-20 00:00:00", true)]
    public void Created_Init(Guid id, string name, string email, string username, string password, string role, DateTime createdAt, bool active)
    {
        var user = new User
        {
            Id = id,
            Name = name,
            Email = email,
            Username = username,
            Password = password,
            Role = role,
            CreatedAt = createdAt,
            Active = active
        };

        user.Should()
            .NotBeNull();

        user.CreatedAt
            .Should()
            .Be(createdAt);

        user.Active
            .Should()
            .BeTrue();

        user.Id
            .Should()
            .Be(id);

        user.Name
            .Should()
            .Be(name);

        user.Email
            .Should()
            .Be(email);

        user.Username
            .Should()
            .Be(username);

        user.Password
            .Should()
            .Be(password);

        user.Role
            .Should()
            .Be(role);
    }
}
