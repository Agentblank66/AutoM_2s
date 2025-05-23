namespace AutoMaegler.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string ImageString { get; set; }
        public int CarId { get; set; }

        public Images() { }

        public Images(int id, string imageString, int carId)
        {
            Id = id;
            ImageString = imageString;
            CarId = carId;
        }
    }
}
