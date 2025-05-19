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

        public List<Models.Car> Cars { get; private set; } = new List<Models.Car>()
        {
            new Models.Car(1, "Sedan", "Audi", "A6", "Marineblue", "Petrol", 2020, 356000, 60000, 29.5, 250, 4, 299,"Automatic", 4, 2.0, 6.2, 494, 4, 2000, 2085, true),
            new Models.Car(2, "SUV", "Alfa-Romeo", "Stelvio", "Blue", "Petrol", 2019, 350000, 69000, 12.6, 215, 4, 200, "Automatic", 4, 2.0, 7.2, 469, 4, 1600, 1635, true),
            new Models.Car(3, "SUV", "Audi", "Q3", "Metallic", "Petrol", 2021, 335000,56000,18.3,206, 4, 150, "Automatisk", 4, 6,9.2,448,4,1800,1470,true)
        };

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
