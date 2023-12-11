using TestWebshop.Models.Database;

namespace TestWebshop.Models.ViewModels
{
    public class CustomerOrder
    {
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
