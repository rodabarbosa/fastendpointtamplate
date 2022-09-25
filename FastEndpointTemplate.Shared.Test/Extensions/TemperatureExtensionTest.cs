namespace FastEndpointTemplate.Shared.Test.Extensions;

public class TemperatureExtensionTest
{
    [Theory]
    [InlineData(32, 0, true)]
    [InlineData(30, 0, false)]
    public void ToCelsiusTest(decimal fahrenheit, decimal celsius, bool expected)
    {
        var actual = fahrenheit.ToCelsius();
        if (expected)
            Assert.Equal(celsius, actual);
        else
            Assert.NotEqual(celsius, actual);
    }

    [Theory]
    [InlineData(0, 32, true)]
    [InlineData(0, 30, false)]
    public void ToFahrenheitTest(decimal celsius, decimal fahrenheit, bool expected)
    {
        var actual = celsius.ToFahrenheit();
        if (expected)
            Assert.Equal(fahrenheit, actual);
        else
            Assert.NotEqual(fahrenheit, actual);
    }
}
