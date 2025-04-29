namespace AutoMaegler.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
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

        public Car(){ }


        public Car(int id, string type, string brand, string color, string fuel, int modelYear, int price, int mileage, double kmPrL, int topSpeed, int doors, int horsePower, string gear, int cylinders, double motorSize, double zeroToOneHundred, int length, int numOffWheels, double maxPull, int weight, bool status)
        {
            Id = id;
            Type = type;
            Brand = brand;
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
    }
}
