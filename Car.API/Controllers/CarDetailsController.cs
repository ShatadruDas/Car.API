using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD.Car.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarDetailsController : ControllerBase
    {
        private static readonly string[] CarNames = new[]
        {
            "Infinity", "Rocket-X", "Cruiser", "Shepard", "RoadStar", "Trucker-Y"
        };

        private static readonly string[] Colors = new[]
      {
            "Red", "Blue", "Steel", "Grey", "Peach", "Sea-Green"
        };

        private readonly ILogger<CarDetailsController> _logger;

        public CarDetailsController(ILogger<CarDetailsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CarDetails> Get()
        {
            _logger.LogInformation("Get Car Details Started");
            var rng = new Random();
            var _carDetails= Enumerable.Range(1, 6).Select(index => new CarDetails
            {
                TopSpeed = rng.Next(140, 220),
                Price = rng.Next(400000, 2100000),
                Name = CarNames[index-1],
                Color=Colors[rng.Next(Colors.Length)]
            })
            .ToArray();

            _logger.LogInformation("Car Details Has Been Retrieved");

            return _carDetails;
        }

        
    }
}
