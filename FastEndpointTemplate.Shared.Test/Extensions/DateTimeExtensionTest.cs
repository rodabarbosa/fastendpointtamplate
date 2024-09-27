namespace FastEndpointTemplate.Shared.Test.Extensions;

public class DateTimeExtensionTest
{
    [Fact]
    public void ToDatetimeConvert()
    {
        var date = "2021-01-01 00:00:00";
        var result = date.ToDateTime();

        result
            .Should()
            .BeSameDateAs(new DateTime(2021, 01, 01, 00, 00, 00));
    }
}
