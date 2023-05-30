using Cars_API_MySQL.Data.Repositories;
using Cars_API_MySQL.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cars_API_MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _carRepository.GetAllCars());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDetails(int id)
        {
            return Ok(await _carRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            if (car == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _carRepository.InsertCar(car);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] Car car)
        {
            if (car == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _carRepository.UpdateCar(car);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carRepository.DeleteCar(new Car { Id = id });

            return NoContent();
        }
    }
}
