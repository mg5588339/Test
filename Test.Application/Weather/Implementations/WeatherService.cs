using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Common.Interfaces;
using Test.Application.Weather.Interfaces;
using Test.Domain.Entities.Root;

namespace Test.Application.Weather.Implementations
{
    public class WeatherService : IWeatherService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<WeatherService> _logger;
        public WeatherService(IApplicationDbContext application, ILogger<WeatherService> logger)
        {
            _context = application;
            _logger = logger;
        }

        public async Task<Root> GetWeatherForLocation(string locationName)
        {
            try
            {
                var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?q=california&appid=159e491e6caa2e4e0fc4682eea0c2602");
                var restRequest = new RestRequest(Method.POST);
                var res = client.Execute(restRequest);
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(res.Content);

                if (model != null && model.Main.Temp > 14)
                {
                    var data = new Domain.Entities.Weathers.Weather()
                    {
                        Country = model.Sys.Country,
                        CityName = model.Name,
                        TimeZone = model.Timezone,
                        Tmp = model.Main.Temp,
                    };

                    await _context.Weathers.AddAsync(data);
                    await _context.SaveChangesAsync(new System.Threading.CancellationToken());
                }
                return model;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }

        }

       


    }
}
