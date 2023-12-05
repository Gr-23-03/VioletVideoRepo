namespace TestWebshop.Models.ViewModels
{
    public class DisplayCartVM
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public decimal Price { get; set; }

        public string? PictureUrl { get; set; }

        public int Quantity { get; set; }

        private decimal TotalPrice { get; set; }


        public DisplayCartVM()
        {
            TotalPrice = Price * Quantity;
        }

    }
}
