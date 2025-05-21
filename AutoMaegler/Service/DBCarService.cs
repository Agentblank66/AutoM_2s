
using AutoMaegler.EFDbContext;
using AutoMaegler.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMaegler.Service
{
    public class DBCarService
    {
        //    //Skal returnere list fra DB
        //}
 
        public async Task<List<Car>> GetCars()
        {
            using (var context = new CarDBContext())
            {
                return await context.Cars.ToListAsync();
            }
        }

        public async Task AddCar(Car car)
        {
            using (var context = new CarDBContext())
            { 
                context.Cars.Add(car);
                await context.SaveChangesAsync();
            }
        }

        public async Task SaveCars(List<Car> cars)
        {
            using (var context = new CarDBContext())
            {
                foreach (Car car in cars)
                {
                    context.Cars.Add(car);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
