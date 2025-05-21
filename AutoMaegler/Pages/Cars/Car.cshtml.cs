using AutoMaegler.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages.Cars
{
    public class CarModel : PageModel
    {

        private ICarService _carService;

        public Models.Car Car { get; set; }

        public CarModel(ICarService carService)
        {
            _carService = carService;
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
