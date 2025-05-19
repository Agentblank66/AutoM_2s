using AutoMaegler.Models;

namespace AutoMaegler.MockData
{
    public class MockCars
    {

        private static List<Car> _cars = new List<Car>()
        {
            new Car(1, "Sedan", "Audi", "A6", "Marineblue", "Petrol", 2020, 356000, 60000, 29.5, 250, 4, 299,"Automatic", 4, 2.0, 6.2, 494, 4, 2000, 2085, true),
            new Car(2, "SUV", "Alfa-Romeo", "Stelvio", "Blue", "Petrol", 2019, 350000, 69000, 12.6, 215, 4, 200, "Automatic", 4, 2.0, 7.2, 469, 4, 1600, 1635, true)
        };

        public static List<Car> GetMockCars() { return _cars; }

    }
}
