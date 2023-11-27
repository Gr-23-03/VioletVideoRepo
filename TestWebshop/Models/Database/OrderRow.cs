using System.ComponentModel.DataAnnotations;

namespace TestWebshop.Models.Database
{
    public class OrderRow
    {

        public int Id { get; set; }         //PK(?)
        public int OrderId { get; set; }
        public int MovieId { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }  // FK
        public virtual Movie Movie { get; set; }  // FK
    }
}
