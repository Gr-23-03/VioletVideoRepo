namespace TestWebshop.Models.ViewModels
{
    public class DisplayCartVM
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public decimal Price { get; set; }

        public string? PictureUrl { get; set; }

        public int Quantity { get; set; }

        // computed property -> always calculated when accessing.
        public decimal TotalPrice => Price * Quantity;


        //public DisplayCartVM()
        //{
        //    TotalPrice = Price * Quantity;
        //}

    }
}
