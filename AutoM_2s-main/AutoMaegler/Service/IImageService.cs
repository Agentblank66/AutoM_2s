using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public interface IImageService 
    {
        public List<Image> GetImagesByCarId(int carId);
        public List<Image> GetImages();
        public void DeleteImage(int id);
        public Image EditImage (Image image);
        public void AddImage(Image image);
        public Image GetImageById(int Id);
    }
}
