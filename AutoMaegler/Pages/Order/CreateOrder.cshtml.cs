using AutoMaegler.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages.Order
{
    public class OrderModel : PageModel
    {
        /// <summary>
        /// The service for the orders
        /// </summary>
        private IOrderService _orderService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderService"></param>
        public OrderModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// The orders that is to be created
        /// </summary>
        [BindProperty]
        public Models.Order Order { get; set; }

        /// <summary>
        /// The type of order
        /// </summary>
        /// <returns> To current page </returns>
        public IActionResult OnGet()
        {
            return Page();
        }

        /// <summary>
        /// Calls the AddOrder method from the service
        /// </summary>
        /// <returns> To either GetAllOrders page or the same page </returns>
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _orderService.AddOrder(Order);
                return RedirectToPage("GetAllOrders");
            }
            return Page();
        }
    }
}
