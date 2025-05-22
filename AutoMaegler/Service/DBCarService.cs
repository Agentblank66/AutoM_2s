using AutoMaegler.EFDbContext;
using AutoMaegler.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMaegler.Service
{
    public class DBCarService
    {
        private readonly CarDBContext _context;

        public DBCarService(CarDBContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }

        public async Task SaveCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                _context.Cars.Add(car);
            }
            await _context.SaveChangesAsync();
        }
    }
}
