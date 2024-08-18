namespace Integrations.CountriesNowRestApi;

public interface ICountriesNowService
{
    Task<IEnumerable<string>> GetCities();
}
