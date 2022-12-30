using Impar.Cars.Api.Models;

namespace Impar.Cars.Api.Repositories.Interfaces
{
    public interface ICarRepository
    {

        public Task<IList<CarDto>> GetCars();
        public Task<CarDto> CreateCar(CarDto car);
        public Task DeleteCar(int id);
        public Task UpdateCar(int id, CarDto car);
    }
}
