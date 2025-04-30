using AutoMaegler.Models;
using System.Security.Cryptography.X509Certificates;

namespace AutoMaegler.Service
{
    public class CarService: ICarService
    {
        private List<Car> _cars;

        public List<Car> GetCars()
        {
            return _cars;
        }

        public void AddCar(Car car)
        {
            _cars.Add(car);
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

        public Car? GetCar(int id)
        {
            foreach (Car car in _cars) 
            { 
                if (car.Id == id) return car;
            }
            return null;
        }
        public Car? DeleteCar(int id)
        {
            Car car = GetCar(id);
            _cars.Remove(GetCar(id));
            return car;
        }
        public IEnumerable<Car> NameSearch(string str)
        {
            List<Car> allCars = GetCars();
            List<Car> brandMatch = new List<Car>();
            List<Car> typeOfmatch = new List<Car>();
            List<Car> Result = new List<Car>();

            // check Brand Match
            // Add to brandmatch List
            // remove from allcars List
            foreach (Car car in allCars) 
            { 
                if(car.Brand == str) 
                { 
                    brandMatch.Add(car);
                    allCars.Remove(car);
                }
            }

            // check Brand Match
            // Add to typematch List
            // remove from allcars List
            foreach (Car car in allCars)
            {
                if (car.Type == str)
                {
                    typeOfmatch.Add(car);
                    allCars.Remove(car);
                }
            }

            Result = brandMatch;
            Result += typeOfmatch;

        }

        public IEnumerable<Car> PriceFilter(int minPrice, int maxPrice)
        {

        }
    }
}
