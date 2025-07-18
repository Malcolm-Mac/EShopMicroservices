namespace Shopping.Web.Pages
{
    public class ConfirmationModel : PageModel
    {
        public string Message {get;set;} = default!;

        public void OnGetContact()
        {
            Message = "Your email was sent successfully.";
        }

        public void OnGetOrderSubmitted()
        {
            Message = "Your order is submitted successfully.";
        }
    }
}
