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
        Assert.NotEmpty(result);
    }

    [Fact]
    public void GetExpression_Valid()
    {
        var dt = new DateTime(2000, 01, 01);
        var result = _repository.Get(x => x.Date > dt);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task GetByIdASync()
    {
        var guid = Guid.Parse("10fd1392-3b4c-431a-b6dc-19cfba4ea269");
        var result = await _repository.GetByIdAsync(guid);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task DeleteAsync()
    {
        var context = ContextUtil.GetContext();
        var repository = new WeatherForecastRepository(context);
        var guid = Guid.Parse("10fd1392-3b4c-431a-b6dc-19cfba4ea269");
        await repository.DeleteAsync(guid);

        Assert.True(true);
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

        await _repository.AddAsync(weather);
        Assert.NotEqual(Guid.Empty, weather.Id);
    }

    [Fact]
    public async Task UpdateAsync()
    {
        var guid = Guid.Parse("10fd1392-3b4c-431a-b6dc-19cfba4ea269");
        var weather = await _repository.GetByIdAsync(guid);

        weather.TemperatureCelsius = 36;

        await _repository.UpdateAsync(weather);
        Assert.True(true);
    }

    [Fact]
    public async Task UpdateRangeAsync()
    {
        var weathers = _repository.Get().Take(2).ToList();

        weathers.ForEach(x => x.TemperatureCelsius = 0);

        await _repository.UpdateRangeAsync(weathers);
        Assert.True(true);
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

        await _repository.AddRangeAsync(weathers);
        Assert.True(true);
    }

    [Fact]
    public async Task DeleteRangeAsync()
    {
        var context = ContextUtil.GetContext();
        var repository = new WeatherForecastRepository(context);
        var weathers = repository.Get().Take(2).ToList();

        await repository.DeleteRangeAsync(weathers);

        Assert.True(true);
    }
}
