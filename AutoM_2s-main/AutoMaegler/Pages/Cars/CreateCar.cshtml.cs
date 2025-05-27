using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;

namespace AutoMaegler.Pages.Cars
{
    public class CreateCarModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly IWebHostEnvironment _environment;
        private readonly IImageService _imageService;

        [BindProperty]
        public Car Car { get; set; }

        [BindProperty]
        public IFormFile CarImage { get; set; }

        public CreateCarModel(ICarService carService, IWebHostEnvironment environment, IImageService imageService)
        {
            _carService = carService;
            _environment = environment;
            _imageService = imageService;
        }

        public void OnGet()
        {
            // Intet specielt på GET
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("OnPostAsync() kaldt");

            if (!ModelState.IsValid)
            {
                return Page(); // Håndter valideringsfejl korrekt
            }

            // Gem bilen og få det genererede Id
            var createdCar = await _carService.AddCarAsync(Car);

            // Hvis billede blev uploadet
            if (CarImage != null && CarImage.Length > 0)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "car-images");

                // Opret mappen hvis den ikke findes
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Unik filnavn baseret på bil-id
                var uniqueFileName = $"{Path.GetFileNameWithoutExtension(CarImage.FileName)}_{createdCar.Id}{Path.GetExtension(CarImage.FileName)}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Gem billede til filesystem
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await CarImage.CopyToAsync(stream);
                }

                // Opret Image-objekt og gem i DB
                var image = new Image
                {
                    CarId = createdCar.Id,
                    ImageString = $"/car-images/{uniqueFileName}"
                };

                await _imageService.AddImageAsync(image);
            }

            // Redirect til biloversigt
            return RedirectToPage("/Cars/Cars");
        }

    }
}
