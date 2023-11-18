using Core;

using Microsoft.AspNetCore.Mvc;

using Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CarController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;
        private readonly ICarService _carService;

        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        [HttpGet(Name = "Init")]
        public async Task Init()
        {
            await _carService.Init();
        }

        [HttpGet(Name = "GetCars")]
        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _carService.LoadAll();
        }
    }
}
