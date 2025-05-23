using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public class DBImageService : 
    {

        private List<Images> _images;


        public void AddImage(Images image)
        {
            _images.Add(image);
            
        }
    }
}
