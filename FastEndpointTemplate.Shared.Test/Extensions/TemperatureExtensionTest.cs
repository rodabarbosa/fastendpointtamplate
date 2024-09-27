namespace FastEndpointTemplate.Shared.Test.Extensions;

public class TemperatureExtensionTest
{
    [Theory]
    [InlineData(0, 32.0)]
    [InlineData(-1.0, 30.2)]
    [InlineData(10.0, 50.0)]
    public void Celsius_To_Fahrenheit_Should_Success(decimal celsius, decimal fahrenheit)
    {
        var celsiusToFahrenheit = celsius.ToFahrenheit();
        celsiusToFahrenheit
            .Should()
            .Be(fahrenheit);
    }

    [Fact]
    public void Nullable_Celsius_To_Fahrenheit_Should_Success()
    {
        decimal? celsius = 0;
        var celsiusToFahrenheit = celsius.ToFahrenheit();
        celsiusToFahrenheit
            .Should()
            .Be(32M);
    }

    [Fact]
    public void Null_Celsius_To_Fahrenheit_Should_Return_Null()
    {
        decimal? celsius = null;
        var celsiusToFahrenheit = celsius.ToFahrenheit();
        celsiusToFahrenheit
            .Should()
            .BeNull();
    }


    [Theory]
    [InlineData(0, 32.1)]
    [InlineData(-1, 30.4)]
    [InlineData(10, 49)]
    public void Celsius_To_Fahrenheit_Should_Fail(decimal celsius, decimal fahrenheit)
    {
        var celsiusToFahrenheit = celsius.ToFahrenheit();
        celsiusToFahrenheit
            .Should()
            .NotBe(fahrenheit);
    }

    [Theory]
    [InlineData(0, 32)]
    [InlineData(-1, 30.2)]
    [InlineData(10, 50)]
    public void Fahrenheit_To_celsius_Should_Success(decimal celsius, decimal fahrenheit)
    {
        var fahrenheitToCelsius = fahrenheit.ToCelsius();
        fahrenheitToCelsius
            .Should()
            .Be(celsius);
    }

    [Fact]
    public void Nullable_Fahrenheit_To_Celsiust_Should_Success()
    {
        decimal? fahrenheit = 32;
        var celsiusToFahrenheit = fahrenheit.ToCelsius();
        celsiusToFahrenheit
            .Should()
            .Be(0);
    }

    [Fact]
    public void Null_Fahrenheit_To_celsius_Should_Return_Null()
    {
        decimal? fahrenheit = null;
        var fahrenheitToCelsius = fahrenheit.ToCelsius();
        fahrenheitToCelsius
            .Should()
            .BeNull();
    }

    [Theory]
    [InlineData(0, 32.1)]
    [InlineData(-1, 30.4)]
    [InlineData(10, 49)]
    public void Fahrenheit_To_celsius_Should_Fail(decimal celsius, decimal fahrenheit)
    {
        var fahrenheitToCelsius = fahrenheit.ToFahrenheit();
        fahrenheitToCelsius
            .Should()
            .NotBe(celsius);
    }
}
