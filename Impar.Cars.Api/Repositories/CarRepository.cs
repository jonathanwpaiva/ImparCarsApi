using Impar.Cars.Api.Models;
using Impar.Cars.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Impar.Cars.Api.Repositories
{
    public class CarRepository : ICarRepository
    {

        private readonly AppDbContext _dbContext;

        public CarRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<CarDto>> GetCars()
        {
            var cars = await _dbContext.Car.ToListAsync();
            var photos = await _dbContext.Photo.ToListAsync();
            var carsList = new List<CarDto>();

            for (int i = 0; i < cars.Count; i++)
            {
                carsList.Add(new CarDto()
                {
                    id = cars[i].id,
                    name = cars[i].name,
                    status = cars[i].status,
                    Base64 = photos[i].Base64
                });
            }

            return carsList;
        }

        public async Task<CarDto> CreateCar(CarDto car)
        {
            var newCar = new Car();
            var newPhoto = new Photo();

            newCar.name = car.name;
            newCar.status = car.status;
            newPhoto.Base64 = car.Base64;
            _dbContext.Photo.Add(newPhoto);
            await _dbContext.SaveChangesAsync();

            var photos = await _dbContext.Photo.ToListAsync();
            var highestId = photos.Max(photo => photo.id);
            newCar.photoid = highestId;

            _dbContext.Car.Add(newCar);
            await _dbContext.SaveChangesAsync();


            return car;
        }

        public async Task DeleteCar(int id)
        {
            var carToDelete = await _dbContext.Car.FindAsync(id);
            var photoToDelete = await _dbContext.Photo.FindAsync(id);

            //if (carToDelete == null){
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}

            _dbContext.Car.Remove(carToDelete);
            _dbContext.Photo.Remove(photoToDelete);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCar(int id, CarDto car)
        {
            var carToUpdate = await _dbContext.Car.FindAsync(id);
            var photoToUpdate = await _dbContext.Photo.FindAsync(id);

            carToUpdate.name = car.name;
            carToUpdate.status = car.status;
            photoToUpdate.Base64 = car.Base64;

            await _dbContext.SaveChangesAsync();

        }
    }
}
