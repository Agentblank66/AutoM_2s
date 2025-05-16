using System.Security.Cryptography.X509Certificates;

namespace AutoMaegler.Models
{
    public class Car
    {
        /// <summary>
        /// Properties of the Car class.
        /// </summary>
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Fuel { get; set; }
        public int ModelYear { get; set; }
        public int Price { get; set; }
        public int Mileage { get; set; }
        public double KmPrL { get; set; }
        public int TopSpeed { get; set; }
        public int Doors { get; set; }
        public int HorsePower { get; set; }
        public string Gear { get; set; }
        public int Cylinders { get; set; }
        public double MotorSize { get; set; }
        public double ZeroToOneHundred { get; set; }
        public int Length { get; set; }
        public int NumOffWheels { get; set; }
        public double MaxPull { get; set; }
        public int Weight { get; set; }
        public bool Status { get; set; }

        /// <summary>
        /// Default constructor for the Car class.
        /// </summary>
        public Car(){ }

        /// <summary>
        /// Constructor for the Car class with parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="brand"></param>
        /// <param name="color"></param>
        /// <param name="fuel"></param>
        /// <param name="modelYear"></param>
        /// <param name="price"></param>
        /// <param name="mileage"></param>
        /// <param name="kmPrL"></param>
        /// <param name="topSpeed"></param>
        /// <param name="doors"></param>
        /// <param name="horsePower"></param>
        /// <param name="gear"></param>
        /// <param name="cylinders"></param>
        /// <param name="motorSize"></param>
        /// <param name="zeroToOneHundred"></param>
        /// <param name="length"></param>
        /// <param name="numOffWheels"></param>
        /// <param name="maxPull"></param>
        /// <param name="weight"></param>
        /// <param name="status"></param>
        public Car(int id, string type, string brand, string model, string color, string fuel, int modelYear, int price, int mileage, double kmPrL, int topSpeed, int doors, int horsePower, string gear, int cylinders, double motorSize, double zeroToOneHundred, int length, int numOffWheels, double maxPull, int weight, bool status)
        {
            Id = id;
            Type = type;
            Brand = brand;
            Model = model;
            Color = color;
            Fuel = fuel;
            ModelYear = modelYear;
            Price = price;
            Mileage = mileage;
            KmPrL = kmPrL;
            TopSpeed = topSpeed;
            Doors = doors;
            HorsePower = horsePower;
            Gear = gear;
            Cylinders = cylinders;
            MotorSize = motorSize;
            ZeroToOneHundred = zeroToOneHundred;
            Length = length;
            NumOffWheels = numOffWheels;
            MaxPull = maxPull;
            Weight = weight;
            Status = status;
        }

        /// <summary>
        /// Overrides the ToString method to provide a string representation of the Car object.
        /// </summary>
        /// <returns> A string with properties </returns>
        public override string ToString()
        {
            return $"Id: {Id} Type: {Type} Brand: {Brand} Color: {Color} Fuel: {Fuel} ModelYear: {ModelYear} Price: {Price} Mileage: {Mileage} KmPrL: {KmPrL} TopSpeed: {TopSpeed} Doors: {Doors} HorsePower: {HorsePower} Gear: {Gear} Cylinders: {Cylinders} MotorSize: {MotorSize} ZeroToOnehundred: {ZeroToOneHundred} Length: {Length} NumOffWheels: {NumOffWheels} MaxPull: {MaxPull} Weight: {Weight} Status: {Status}";
        }
    }
}
