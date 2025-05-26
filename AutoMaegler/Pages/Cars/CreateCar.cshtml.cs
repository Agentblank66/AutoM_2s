using AutoMaegler.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages.Cars
{
    public class CreateCarModel : PageModel
    {
        private ICarService _CarService;

        public CreateCarModel(ICarService carService)
        {
            _CarService = carService;
        }

        [BindProperty]
        public AutoMaegler.Models.Car Car { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _CarService.AddCar(Car);
            return RedirectToPage("/Cars/createcar");
        }
    }
}
