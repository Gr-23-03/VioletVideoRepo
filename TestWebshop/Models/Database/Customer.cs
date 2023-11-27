using System.ComponentModel.DataAnnotations;

namespace TestWebshop.Models.Database
{
    public class Customer
    {

        //[Key]
        //public int Id { get; set; }
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        //public int? BillingAddress { get; set; }
        //public decimal BillingZip { get; set; }
        //public int BillingCity { get; set; }
        //public int DeliveryAddress { get; set; }
        //public int DeliveryZip { get; set; }
        //public int DeliveryCity { get; set; }
        //public int EmailAddress { get; set; }

        //public int PhoneNo { get; set; }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Billing City")]
        public string BillingCity { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "ZipCode")]
        public string BillingZip { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Delivery City")]
        public string DeliveryCity { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "ZipCode")]
        public string DeliveryZip { get; set; }


        [Required]
        [StringLength(255)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]

        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }  //Many relations with

    }
}
