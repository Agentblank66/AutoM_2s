using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace AutoMaegler.Models
{
    [Table("Car")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        /// <summary>
        /// Properties of the Car class.
        /// </summary>
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Type { get; set; }
        [Required]
        [StringLength(40)]
        public string Brand { get; set; }
        [Required]
        [StringLength(40)]
        public string Model { get; set; }

        [Required]
        [StringLength(40)]

        public string Color { get; set; }
        [Required]
        [StringLength(40)]
        public string Fuel { get; set; }
        [Required]
        public int ModelYear { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public double KmPrL { get; set; }
        [Required]
        public int TopSpeed { get; set; }
        [Required]
        public int Doors { get; set; }
        [Required]
        public int HorsePower { get; set; }
        [Required]
        [StringLength(20)]
        public string Gear { get; set; }
        [Required]
        public int Cylinders { get; set; }

        [Required]
        public double ZeroToOneHundred { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int NumOffWheels { get; set; }
        [Required]
        public double MaxPull { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
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
            return $"Id: {Id} Type: {Type} Brand: {Brand} Color: {Color} Fuel: {Fuel} ModelYear: {ModelYear} Price: {Price} Mileage: {Mileage} KmPrL: {KmPrL} TopSpeed: {TopSpeed} Doors: {Doors} HorsePower: {HorsePower} Gear: {Gear} Cylinders: {Cylinders} ZeroToOnehundred: {ZeroToOneHundred} Length: {Length} NumOffWheels: {NumOffWheels} MaxPull: {MaxPull} Weight: {Weight} Status: {Status}";
        }
    }
}
