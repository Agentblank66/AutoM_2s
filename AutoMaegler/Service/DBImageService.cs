using AutoMaegler.EFDbContext;
using AutoMaegler.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMaegler.Service
{
    public class DBImageService  
    {

        private readonly ImageDBContext _context;

        public DBImageService(ImageDBContext context)
        {
            _context = context;
        }

        public void AddImage(Image image)
        {
            _context.Images.Add(image);
            
        }

        public async Task<List<Image>> GetImages()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task CreateImage(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
        }

        public async Task Deleteimage(Image image)
        {
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }

        public async Task EditImage(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Image>> GetimageByCarId(int CarId)
        {
            return await _context.Images.ToListAsync();
        }
    }
}
