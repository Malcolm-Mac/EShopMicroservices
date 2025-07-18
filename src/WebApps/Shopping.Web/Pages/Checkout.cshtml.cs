namespace Shopping.Web.Pages
{
    public class CheckoutModel(IBasketService basketService, ILogger<CartModel> logger) : PageModel
    {
        [BindProperty]
        public BasketCheckoutModel Order {get;set;} = default!;
        public ShoppingCartModel Cart {get;set;} = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await basketService.LoadUserBasket();
            return Page();
        }
        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            logger.LogInformation("Checkout button clicked");

            Cart = await basketService.LoadUserBasket();

            if(!ModelState.IsValid)
            {
                return Page();
            }

            Order.CustomerId = new Guid("84629872-98fa-4d84-b2b3-06b949a2aac4");
            Order.UserName = Cart.UserName;
            Order.TotalPrice = Cart.TotalPrice;

            await basketService.CheckoutBasket(new CheckoutBasketRequest(Order));

            return RedirectToPage("Confirmation", "OrderSubmitted");
        } 
    }
}
