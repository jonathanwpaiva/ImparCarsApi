using Impar.Cars.Api.Models;
using Impar.Cars.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Impar.Cars.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet("cars/{skip}/{take}")]
        public async Task<IActionResult> GetCars([FromRoute] int skip, [FromRoute] int take)
        {
            var cars = await _carRepository.GetCars(skip, take);
            return Ok(cars);
        }

        [HttpPost("car")]
        public async Task<ActionResult<CarDto>> CreateCar([FromBody] CarDto car)
        {
            var newCar = await _carRepository.CreateCar(car);

            return CreatedAtAction(nameof(GetCars), new { id = newCar.id }, newCar);
        }

        [HttpPut("car/{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] CarDto car)
        {
            await _carRepository.UpdateCar(id, car);

            return NoContent();
        }

        [HttpDelete("car/{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carRepository.DeleteCar(id);


            return NoContent();
        }

    }
}
