namespace Shopping.Web.Pages
{
    public class OrderListModel(IOrderingService orderingService, ILogger<OrderListModel> logger) : PageModel
    {
        public IEnumerable<OrderModel> Orders {get; set;} = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            var customerId = new Guid("84629872-98fa-4d84-b2b3-06b949a2aac4");
            var response = await orderingService.GetOrdersByCustomer(customerId);
            Orders = response.Orders;
            return Page();
        }
    }
}
