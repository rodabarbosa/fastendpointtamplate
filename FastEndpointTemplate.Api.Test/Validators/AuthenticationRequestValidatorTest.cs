namespace FastEndpointTemplate.Api.Test.Validators;

public class AuthenticationRequestValidatorTest
{
    private readonly AuthenticationRequestValidator _validator;

    public AuthenticationRequestValidatorTest()
    {
        _validator = new AuthenticationRequestValidator();
    }

    [Theory]
    [InlineData("admin", "admin@123")]
    [InlineData("admin", "admin")]
    public void Authentication_Valid(string username, string password)
    {
        var authentication = new AuthenticationRequestContract
        {
            Authentication = new AuthenticationContract(username, password)
        };

        var result = _validator.Validate(authentication);

        result.IsValid
            .Should()
            .BeTrue();
    }
}
