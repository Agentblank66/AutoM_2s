using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMaegler.Service;

namespace AutoMaegler.Pages.Order
{
    public class GetAllOrdersModel : PageModel
    {
        /// <summary>
        /// The service for the orders
        /// </summary>
        private IOrderService _orderService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderService"></param>
        public GetAllOrdersModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// The orders to be shown
        /// </summary>
        public List<Models.Order>? Orders { get; private set; }

        public void OnGet()
        {
        }
    }
}
