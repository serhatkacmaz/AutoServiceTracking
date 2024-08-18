namespace Integrations.CountriesNowRestApi;

public class CountriesNowApiResponse
{
    public bool Error { get; set; }
    public string Msg { get; set; }
    public IEnumerable<string> Data { get; set; }
}