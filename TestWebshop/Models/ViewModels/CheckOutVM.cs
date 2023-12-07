namespace TestWebshop.Models.ViewModels
{


    public class CheckoutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }

        // Add any additional properties needed for the checkout process
    }


    public class CartItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
    }


}