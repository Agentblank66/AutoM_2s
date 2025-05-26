using AutoMaegler.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMaegler.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;

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

        [BindProperty]
        public Models.Order.OrderType SelectedOrderType { get; set; }

        public IEnumerable<SelectListItem> OrderTypes { get; set; }

        /// <summary>
        /// Leasing order Properties
        /// </summary>
        [BindProperty]
        public double? Depositum { get; set; }

        [BindProperty]
        public int startYear { get; set; }

        [BindProperty]
        public int endYear { get; set; }

        [BindProperty]
        public int startMonth { get; set; }

        [BindProperty]
        public int endMonth { get; set; }

        [BindProperty]
        public int startDay { get; set; }

        [BindProperty]
        public int endDay { get; set; }

        [BindProperty]
        public double monthlyPayment { get; set; }

        /// <summary>
        /// Buy order Properties
        /// </summary>
        [BindProperty]
        public double BuyPrice { get; set; }

        [BindProperty]
        public int BuyYear { get; set; }
        
        [BindProperty]
        public int BuyMonth { get; set; }
        
        [BindProperty]
        public int BuyDay { get; set; }

        /// <summary>
        /// Sale order Properties
        /// </summary>
        [BindProperty]
        public double SalePrice { get; set; }

        [BindProperty]
        public int SaleYear { get; set; }
        
        [BindProperty]
        public int SaleMonth { get; set; }
        
        [BindProperty]
        public int SaleDay { get; set; }

        /// <summary>
        /// The type of order
        /// </summary>
        /// <returns> To current page </returns>
        public IActionResult OnGet()
        {
            OrderTypes = Enum.GetValues(typeof(Models.Order.OrderType))
            .Cast<Models.Order.OrderType>()
            .Select(ot => new SelectListItem
            {
                Value = ot.ToString(),
                Text = ot.ToString()
            });

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
                // Create the correct order type based on selection
                switch (SelectedOrderType)
                {
                    case Models.Order.OrderType.Leasing:
                        Order = new OrderLeasing
                        {
                            Id = Order.Id,
                            Car = Order.Car,
                            Employee = Order.Employee,
                            Customer = Order.Customer,
                            Type = SelectedOrderType,
                            Depositum = Depositum ?? 0,
                            StartYear = startYear,
                            EndYear = endYear,
                            StartMonth = startMonth,
                            EndMonth = endMonth,
                            StartDay = startDay,
                            EndDay = endDay,
                            MonthlyPayment = monthlyPayment
                        };
                        break;
                    case Models.Order.OrderType.Buy:
                        Order = new OrderBuy
                        {
                            Id = Order.Id,
                            Car = Order.Car,
                            Employee = Order.Employee,
                            Customer = Order.Customer,
                            Type = SelectedOrderType,
                            BuyPrice = BuyPrice,
                            Year = BuyYear,
                            Month = BuyMonth,
                            Day = BuyDay
                        };
                        break;
                    case Models.Order.OrderType.Sale:
                        Order = new OrderSale
                        {
                            Id = Order.Id,
                            Car = Order.Car,
                            Employee = Order.Employee,
                            Customer = Order.Customer,
                            Type = SelectedOrderType,
                            SalePrice = SalePrice,
                            Year = SaleYear,
                            Month = SaleMonth,
                            Day = SaleDay
                        };
                        break;
                }

                _orderService.AddOrder(Order);
                return RedirectToPage("GetAllOrders");
            }
            // Re-populate OrderTypes for redisplay
            OrderTypes = Enum.GetValues(typeof(Models.Order.OrderType))
                .Cast<Models.Order.OrderType>()
                .Select(ot => new SelectListItem
                {
                    Value = ot.ToString(),
                    Text = ot.ToString()
                });
            return Page();
        }
    }
}
