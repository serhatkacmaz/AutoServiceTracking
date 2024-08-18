using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.CountriesNowRestApi;

public interface ICountriesNowService
{
    Task<IEnumerable<string>> GetCities();
}
