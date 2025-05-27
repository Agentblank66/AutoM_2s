using AutoMaegler.Models;
using AutoMaegler.EFDbContext;
using System.Collections.Generic;
using System.Linq;

namespace AutoMaegler.Service
{
    public class DBImageService
    {
        private readonly ImageDBContext _context;

        public DBImageService(ImageDBContext context)
        {
            _context = context;
        }

        public async Task AddImageAsync(Image image)
        {
            _context.Image.Add(image);
            await _context.SaveChangesAsync(); // Husk: denne kræver at din kontekst er async-kompatibel
        }

        public void DeleteImage(int id)
        {
            var image = _context.Image.Find(id);
            if (image != null)
            {
                _context.Image.Remove(image);
                _context.SaveChanges();
            }
        }

        public Image EditImage(Image image)
        {
            var existing = _context.Image.Find(image.Id);
            if (existing != null)
            {
                existing.ImageString = image.ImageString;
                existing.CarId = image.CarId;
                _context.SaveChanges();
            }
            return existing;
        }

        public Image GetImageById(int id)
        {
            return _context.Image.Find(id);
        }

        public List<Image> GetImages()
        {
            return _context.Image.ToList();
        }

        // 🔥 Tilføj denne metode – det er her fejlen opstår hvis den mangler
        public List<Image> GetImagesByCarId(int carId)
        {
            return _context.Image.Where(i => i.CarId == carId).ToList();
        }
    }
}
