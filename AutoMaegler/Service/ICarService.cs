using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public interface ICarService
    {
        /// <summary>
        /// Methods that any class implementing this interface must implement.
        /// </summary>
        public List<Car> GetCars();
        public void AddCar(Car car);
        public void UpdateCar(Car car);
        public Car GetCar(int id);
        public Car DeleteCar(int id);
        public IEnumerable<Car> NameSearch(string str);
        public IEnumerable<Car> PriceFilter(int minPrice, int maxPrice);

    }
}
