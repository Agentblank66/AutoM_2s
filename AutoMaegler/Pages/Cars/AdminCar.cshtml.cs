using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages.Cars
{
    public class AdminCarModel : PageModel
    {
		private readonly ICarService _carService;

		public AdminCarModel(ICarService carService)
		{
			_carService = carService;
		}

		public List<Car> Cars { get; set; } = new();

		public void OnGet()
		{
			Cars = _carService.GetCars();
		}
	}
}
