namespace FastEndpointTemplate.Api.Test.Validators;

public class AuthenticationRequestValidatorTest
{
    private readonly AuthenticationRequestValidator _validator;

    public AuthenticationRequestValidatorTest()
    {
        _validator = new AuthenticationRequestValidator();
    }

    [Theory]
    [InlineData("admin", "admin@123", true)]
    [InlineData("admin", "admin", false)]
    public void Authentication_Valid(string username, string password, bool valid)
    {
        var authentication = new AuthenticationRequestContract
        {
            Authentication = new AuthenticationContract
            {
                Username = username,
                Password = password
            }
        };

        var result = _validator.Validate(authentication);

        Assert.True(result.IsValid);
    }
}
