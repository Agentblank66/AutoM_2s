using AutoMaegler.EFDbContext;
using AutoMaegler.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AutoMaegler.Service
{
    public class DBCarService
    {
        public void SaveDBCars(List<Car> cars)
        {

        }
        ////public IEnumerable<Car> GetDBCars()
        //{
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
                context.SaveChanges();
            }
        }
        public async Task SaveItems(List<Car> cars)
        {
            using (var context =new CarDBContext())
            {
                foreach (Car car in cars)
                {
                    context.Cars.Add(car);
                    context.SaveChanges();
                }
                context.SaveChanges();
            }
        }
    }

}
