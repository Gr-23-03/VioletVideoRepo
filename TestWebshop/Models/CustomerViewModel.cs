using Microsoft.AspNetCore.Mvc.Rendering;
using TestWebshop.Models.Database;
using TestWebshop.Models.ViewModels;

namespace TestWebshop.Models
{
    public class CustomerViewModel
    {
        public List<Customer> customers;
        public SelectList customer; 
        public string Customer { get; set; }
        public Pager pager { get; set; }

    }
}
