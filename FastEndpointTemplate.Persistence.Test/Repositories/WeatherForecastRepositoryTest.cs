using FastEndpointTemplate.Domain.Entities;

namespace FastEndpointTemplate.Persistence.Test.Repositories;

public class WeatherForecastRepositoryTest
{
    private readonly WeatherForecastRepository _repository;

    public WeatherForecastRepositoryTest()
    {
        var context = ContextUtil.GetContext();
        _repository = new WeatherForecastRepository(context);
    }

    [Fact]
    public void Get_Valid()
    {
        var result = _repository.Get();

        result.Should()
            .NotBeNull();
    }

    [Fact]
    public void GetExpression_Valid()
    {
        var dt = new DateTime(2000, 01, 01);
        var result = _repository.Get(x => x.Date > dt);

        result.Should()
            .NotBeEmpty();
    }

    [Fact]
    public async Task GetByIdASync()
    {
        var guid = Guid.Parse("43903282-c4b3-42f9-99cc-fd234ee6941d");
        var result = await _repository.GetByIdAsync(guid, CancellationToken.None);

        result.Should()
            .NotBeNull();
    }

    [Fact]
    public async Task DeleteAsync()
    {
        var context = ContextUtil.GetContext();
        var repository = new WeatherForecastRepository(context);
        var guid = Guid.Parse("10fd1392-3b4c-431a-b6dc-19cfba4ea269");
        var action = () => repository.DeleteAsync(guid, CancellationToken.None);

        await action.Should()
            .NotThrowAsync();
    }

    [Fact]
    public async Task AddAsync()
    {
        var weather = new WeatherForecast
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            TemperatureCelsius = 0,
            Summary = null
        };

        await _repository.AddAsync(weather, CancellationToken.None);

        weather.Id
            .Should()
            .NotBe(Guid.Empty);
    }

    [Fact]
    public async Task UpdateAsync()
    {
        var weather = await _repository.Get()
            .LastAsync();

        weather!.TemperatureCelsius = 36;

        var action = () => _repository.UpdateAsync(weather, CancellationToken.None);
        await action.Should()
            .NotThrowAsync();
    }

    [Fact]
    public async Task UpdateRangeAsync()
    {
        var weathers = _repository.Get().Take(2).ToList();

        weathers.ForEach(x => x.TemperatureCelsius = 0);

        var action = () => _repository.UpdateRangeAsync(weathers, CancellationToken.None);
        await action.Should()
            .NotThrowAsync();
    }

    [Fact]
    public async Task AddRangeAsync()
    {
        var weathers = new List<WeatherForecast>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                TemperatureCelsius = 0,
                Summary = null
            },
            new()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                TemperatureCelsius = 32,
                Summary = null
            }
        };

        var action = () => _repository.AddRangeAsync(weathers, CancellationToken.None);
        await action.Should()
            .NotThrowAsync();
    }

    [Fact]
    public async Task DeleteRangeAsync()
    {
        var guid = Guid.Parse("e3977d67-d913-4e1e-bb5b-ef36deafc796");
        var context = ContextUtil.GetContext();
        var repository = new WeatherForecastRepository(context);
        var weathers = repository.Get(x => x.Id == guid).ToList();

        var action = () => repository.DeleteRangeAsync(weathers, CancellationToken.None);
        await action.Should()
            .NotThrowAsync();
    }
}
