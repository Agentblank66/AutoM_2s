using AutoMaegler.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Item
{
	public class EditCarModel : PageModel
	{
		private ICarService _CarService;

		public EditCarModel(ICarService CarService)
		{
			_CarService = CarService;
		}

		[BindProperty]
		public AutoMaegler.Models.Car Car { get; set; }

		public IActionResult OnGet(int id)
		{
			Car = _CarService.GetCar(id);
			if (Car == null)
				return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_CarService.UpdateCar(Car);
			return RedirectToPage("Cars");
		}
	}
}
