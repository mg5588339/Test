using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Application.Common.Response;
using Test.Application.Weather.Interfaces;
using Test.WebAPI.Controllers;

namespace Test.WebApi.Controllers
{
    public class WeatherController : BaseApiController
    {
        #region consrector

        private readonly IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        #endregion

        #region GetWeatherForLocations

        [HttpGet("GetWeatherForLocations")]
        public async Task<IActionResult> GetWeatherForLocations(string locationName)
        {
            return JsonResponseStatus.Success(returnData: await _weatherService.GetWeatherForLocation(locationName));
        }

        #endregion
    }
}
