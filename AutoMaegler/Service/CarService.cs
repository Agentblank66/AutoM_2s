using AutoMaegler.Models;
using System.Security.Cryptography.X509Certificates;

namespace AutoMaegler.Service
{
    public class CarService: ICarService
    {
        private List<Car> _cars;

        public List<Car> GetCars()
        {

        }

        public void AddCar(Car car)
        {

        }
        public void UpdateCar(Car car)
        { 
            if (_cars != null)
            {
                foreach (Car c in _cars)
                {
                    if (c.Id == car.Id)
                    {
                        c.Id = car.Id;
                        c.Type = car.Type;
                        c.Brand = car.Brand;
                        c.Color = car.Color;
                        c.Fuel = car.Fuel;
                        c.ModelYear = car.ModelYear;
                        c.Price = car.Price;
                        c.Mileage = car.Mileage;
                        c.KmPrL = car.KmPrL;
                        c.TopSpeed = car.TopSpeed;
                        c.Doors = car.Doors;
                        c.HorsePower = car.HorsePower;
                        c.Gear = car.Gear;
                        c.Cylinders = car.Cylinders;
                        c.MotorSize = car.MotorSize;
                        c.ZeroToOneHundred = car.ZeroToOneHundred;
                        c.Length = car.Length;
                        c.NumOffWheels = car.NumOffWheels;
                        c.MaxPull = car.MaxPull;
                        c.Weight = car.Weight;
                        c.Status = car.Status;
                    }
                }
            }

        }
        public Car DeleteCar(int id)
        {

        }
        public IEnumerable<Car> NameSearch(string str)
        {

        }
        public IEnumerable<Car> PriceFilter(int minPrice, int maxPrice)
        {

        }
    }
}
