using AutoMaegler.MockData;
using AutoMaegler.Models;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using Image = AutoMaegler.Models.Image;

namespace AutoMaegler.Service
{
    public class ImageService : IImageService
    {
        private List<Image> _image;


        private DBImageService _dbImageService;

        public ImageService(DBImageService dbImageService)
        {
            _dbImageService = dbImageService;
            _image = _dbImageService.GetImages().Result.ToList();
        }

        public List<Image> GetImagesByCarId(int carId)
        {
            return _dbImageService.GetimageByCarId(carId).Result.ToList();
        }

        public List<Image> GetImages()
        {
            return _image;
        }

        public Image? GetImageById(int id)
        {
            foreach (var image in _image) 
            { 
                if (image.Id == id)
                {
                    return image;
                }
            }
            return null;
        }

        public void DeleteImage(int id)
        {
            Image image = GetImageById(id);
            _image.Remove(GetImageById(id));
            _dbImageService.Deleteimage(image);
        }

        public Image EditImage(Image image)
        {
            if(_image != null)
            {
                foreach (Image i in _image)
                {
                    if (i.Id == image.Id)
                    {
                        i.Id = image.Id;
                        i.ImageString = image.ImageString;
                        i.CarId = image.CarId;

                        _dbImageService.EditImage(image);
                        return i;
                    }
                }
            }
            return image;
        }

        public void AddImage(Image image)
        {
            _image.Add(image);
            _dbImageService.AddImage(image);
        }
    }

}
