using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;

namespace AutoMaegler.Pages.Cars
{
    public class CarModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly IWebHostEnvironment _environment;
        private readonly IImageService _imageService;

        public Models.Car Car { get; set; }

       

        public CarModel(ICarService carService, IWebHostEnvironment environment, IImageService imageService)
        {
            _carService = carService;
            _environment = environment;
            _imageService = imageService;
        }

        public IActionResult OnGet(int id)
        {
            Car = _carService.GetCar(id);
            if (Car == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

    }
}
