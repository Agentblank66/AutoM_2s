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

        /// <summary>
        /// The search string for the orders
        /// </summary>
        [BindProperty]
        public string SearchString { get; set; }

        /// <summary>
        /// The minimum price for the orders
        /// </summary>
        [BindProperty]
        public double MinPrice { get; set; }

        /// <summary>
        /// The maximum price for the orders
        /// </summary>
        [BindProperty]
        public double MaxPrice { get; set; }

        /// <summary>
        /// The minimum leasing for the orders
        /// </summary>
        [BindProperty]
        public double MinLeasing { get; set; }

        /// <summary>
        /// The maximum leasing for the orders
        /// </summary>
        [BindProperty]
        public double MaxLeasing { get; set; }

        /// <summary>
        /// Searches for orders by customer name
        /// </summary>
        /// <returns> To the same newly updated page </returns>
        public IActionResult OnPostNameSearch()
        {
            Orders = _orderService.NameSearch(SearchString).ToList();
            return Page();
        }

        /// <summary>
        /// Filters the price of the orders
        /// </summary>
        /// <returns> To the same newly updated page </returns>
        public IActionResult OnPostPriceFilter()
        {
            Orders = _orderService.PriceFilter(MinPrice, MaxPrice, MinLeasing, MaxLeasing).ToList();
            return Page();
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnGet()
        {
            Orders = _orderService.GetOrders();
        }
    }
}
