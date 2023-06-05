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

        /// <summary>
        /// Obtiene todos los carros.
        /// </summary>
        /// <returns>
        /// Objeto ActionResult que representa la respuesta HTTP.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _carRepository.GetAllCars());
        }

        /// <summary>
        /// Obtiene los detalles de un carro específico por su ID.
        /// </summary>
        /// <param name="id">ID del carro.</param>
        /// <returns>
        /// Objeto ActionResult que representa la respuesta HTTP.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDetails(int id)
        {
            return Ok(await _carRepository.GetDetails(id));
        }

        /// <summary>
        /// Crea un nuevo carro.
        /// </summary>
        /// <param name="car">Objeto Car que representa el carro a crear.</param>
        /// <returns>
        /// Objeto ActionResult que representa la respuesta HTTP.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            if (car == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _carRepository.InsertCar(car);

            return Created("created", created);
        }

        /// <summary>
        /// Actualiza un carro existente.
        /// </summary>
        /// <param name="car">Objeto Car que representa el carro actualizado.</param>
        /// <returns>
        /// Objeto ActionResult que representa la respuesta HTTP.
        /// </returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] Car car)
        {
            if (car == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _carRepository.UpdateCar(car);

            return NoContent();
        }

        /// <summary>
        /// Elimina un carro por su ID.
        /// </summary>
        /// <param name="id">ID del carro a eliminar.</param>
        /// <returns>
        /// Objeto ActionResult que representa la respuesta HTTP.
        /// </returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carRepository.DeleteCar(new Car { Id = id });

            return NoContent();
        }
    }
}
