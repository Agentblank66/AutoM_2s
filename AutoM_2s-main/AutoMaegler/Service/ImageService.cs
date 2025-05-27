using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public class ImageService : IImageService
    {
        private readonly DBImageService _dbImageService;

        public ImageService(DBImageService dbImageService)
        {
            _dbImageService = dbImageService;
        }

        public async Task AddImageAsync(Image image)
        {
            if (string.IsNullOrEmpty(image.ImageString))
                throw new ArgumentException("Image string cannot be empty");

            await _dbImageService.AddImageAsync(image); // skal også være async
        }


        public void DeleteImage(int id)
        {
            _dbImageService.DeleteImage(id);
        }

        public Image EditImage(Image image)
        {
            return _dbImageService.EditImage(image);
        }

        public Image GetImageById(int id)
        {
            return _dbImageService.GetImageById(id);
        }

        public List<Image> GetImages()
        {
            return _dbImageService.GetImages();
        }

        public List<Image> GetImagesByCarId(int carId)
        {
            return _dbImageService.GetImagesByCarId(carId);
        }
    }
}
