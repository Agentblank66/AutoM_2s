using AutoMaegler.Models;
using System.Security.Cryptography.X509Certificates;

namespace AutoMaegler.Service
{
    public class CarService: ICarService
    {
        /// <summary>
        /// List of cars in the car service.
        /// </summary>
        private List<Car> _cars;

        /// <summary>
        /// Methods to get all cars.
        /// </summary>
        /// <returns> A list of all cars </returns>
        public List<Car> GetCars()
        {
            return _cars;
        }

        /// <summary>
        /// Adds a car to the list of cars.
        /// </summary>
        /// <param name="car"></param>
        public void AddCar(Car car)
        {
            _cars.Add(car);
        }

        /// <summary>
        /// Updates a car in the list of cars.
        /// </summary>
        /// <param name="car"></param>
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
                        c.Model = car.Model;
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

        /// <summary>
        /// Gets a car by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A car or null </returns>
        public Car? GetCar(int id)
        {
            foreach (Car car in _cars) 
            { 
                if (car.Id == id) return car;
            }
            return null;
        }

        /// <summary>
        /// Deletes a car by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> The deleted car </returns>
        public Car? DeleteCar(int id)
        {
            Car car = GetCar(id);
            _cars.Remove(GetCar(id));
            return car;
        }


        // laves om til 2 metoder 
        // lav endnu en search på fuel
        public IEnumerable<Car> NameSearch(string str)
        {
            List<Car> allCars = GetCars();
            List<Car> brandMatch = new List<Car>();
            List<Car> typeOfMatch = new List<Car>();

            // foreach allcars
            // if match add to list
            // if match remove from list
            foreach (Car car in allCars)
            {
                if (car.Brand == str)
                {
                    brandMatch.Add(car);
                    allCars.Remove(car);
                }
            }

            // foreach allcars
            // if match add to list
            // if match remove from list
            foreach (Car car in allCars)
            {
                if (car.Type == str)
                {
                    typeOfMatch.Add(car);
                    allCars.Remove(car);
                }
            }

            // Combine results from lists
            List<Car> result = new List<Car>();
            result.AddRange(brandMatch);
            result.AddRange(typeOfMatch);

            return result;
        }

        /// <summary>
        /// Filters cars by price range.
        /// </summary>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <returns> A list of cars </returns>
        public IEnumerable<Car> PriceFilter(int minPrice, int maxPrice)
        {
            List<Car> SortedByPriceCars = GetCars();
            List<Car> PriceResult = new List<Car>();
            
            foreach (Car car in SortedByPriceCars)
            {
                if (car.Price >= minPrice && car.Price <= maxPrice)
                {
                    PriceResult.Add(car);
                }
            }
            return PriceResult;
        }
    }
}
