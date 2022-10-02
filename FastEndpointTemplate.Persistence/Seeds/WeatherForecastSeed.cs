using FastEndpointTemplate.Domain.Entities;

namespace FastEndpointTemplate.Persistence.Seeds;

static public class WeatherForecastSeed
{
    private static readonly string[] _summaries = { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    public static IEnumerable<WeatherForecast> GetSeeds()
    {
        var rnd = new Random();

        var lista = new List<WeatherForecast>
        {
            new()
            {
                Id = Guid.Parse("10fd1392-3b4c-431a-b6dc-19cfba4ea269"), // Delete Test
                Date = GetRandomDate(rnd),
                TemperatureCelsius = rnd.Next(-20, 55),
                Summary = _summaries[rnd.Next(_summaries.Length)]
            },
            new()
            {
                Id = Guid.Parse("e3977d67-d913-4e1e-bb5b-ef36deafc796"), // Delete Test
                Date = GetRandomDate(rnd),
                TemperatureCelsius = rnd.Next(-20, 55),
                Summary = _summaries[rnd.Next(_summaries.Length)]
            },
            new()
            {
                Id = Guid.Parse("43903282-c4b3-42f9-99cc-fd234ee6941d"), // Update Test
                Date = GetRandomDate(rnd),
                TemperatureCelsius = 30,
                Summary = _summaries[rnd.Next(_summaries.Length)]
            }
        };

        for (var i = 0; i < 5; i++)
        {
            var weather = new WeatherForecast
            {
                Id = Guid.NewGuid(),
                Date = GetRandomDate(rnd),
                TemperatureCelsius = rnd.Next(-20, 55),
                Summary = _summaries[rnd.Next(_summaries.Length)]
            };

            lista.Add(weather);
        }

        return lista;
    }

    private static DateTime GetRandomDate(Random rnd)
    {
        var rndYear = rnd.Next(1995, DateTime.Now.Year);
        var rndMonth = rnd.Next(1, 12);
        var rndDay = rnd.Next(1, 31);

        return new DateTime(rndYear, rndMonth, rndDay);
    }
}
