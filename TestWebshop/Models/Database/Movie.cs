using System.ComponentModel.DataAnnotations;

namespace TestWebshop.Models.Database
{
    public class Movie
    {
        //Properties

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required]
        [StringLength(100)]
        public string? Director { get; set; }

        [Required]
        public int? ReleaseYear { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Genre { get; set; }

        public string ImageURL { get; set; }

        public ICollection<OrderRow> OrderRows { get; set; }

    }
}