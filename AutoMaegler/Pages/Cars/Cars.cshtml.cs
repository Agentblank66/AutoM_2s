using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages.Cars
{
    public class CarsModel : PageModel
    {
        private ICarService _carService;

        public CarsModel(ICarService carService)
        {
            _carService = carService;
        }

        public List<Models.Car> Cars { get; private set; } = new List<Models.Car>() { };

        [BindProperty]
        public string SearchString { get; set; }
            
        [BindProperty]
        public int MinPrice { get; set; }

        [BindProperty]
        public int MaxPrice { get; set; }


        public void OnGet()
        {
            Cars = _carService.GetCars();
        }
    }
}
