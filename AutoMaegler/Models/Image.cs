namespace AutoMaegler.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageString { get; set; }
        public int CarId { get; set; }

        public Image() { }

        public Image(int id, string imageString, int carId)
        {
            Id = id;
            ImageString = imageString;
            CarId = carId;
        }
    }
}
