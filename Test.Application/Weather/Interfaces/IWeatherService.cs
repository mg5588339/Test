using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Entities.Root;
using static Test.Application.Weather.Implementations.WeatherService;

namespace Test.Application.Weather.Interfaces
{
    public interface IWeatherService
    {
        Task<Root> GetWeatherForLocation(string locationName);
    }
}
