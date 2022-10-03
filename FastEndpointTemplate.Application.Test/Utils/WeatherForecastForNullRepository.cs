using FastEndpointTemplate.Domain.Repositories;
using System.Linq.Expressions;

namespace FastEndpointTemplate.Application.Test.Utils;

public class WeatherForecastForNullRepository : IWeatherForecastRepository
{
    public IQueryable<WeatherForecast> Get()
    {
        return default;
    }

    public IQueryable<WeatherForecast> Get(Expression<Func<WeatherForecast, bool>> predicate)
    {
        return default;
    }

    public Task<WeatherForecast?> GetByIdAsync(Guid id)
    {
        return default;
    }

    public Task AddAsync(WeatherForecast? entity)
    {
        return default;
    }

    public Task AddRangeAsync(IEnumerable<WeatherForecast> entities)
    {
        return default;
    }

    public Task UpdateAsync(WeatherForecast? entity)
    {
        return default;
    }

    public Task UpdateRangeAsync(IEnumerable<WeatherForecast> entities)
    {
        return default;
    }

    public Task DeleteAsync(WeatherForecast? entity)
    {
        return default;
    }

    public Task DeleteAsync(Guid id)
    {
        return default;
    }

    public Task DeleteRangeAsync(IEnumerable<WeatherForecast> entities)
    {
        return default;
    }
}
