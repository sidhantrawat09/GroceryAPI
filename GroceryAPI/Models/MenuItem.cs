using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryAPI.Models
{
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        [Required]
        [MaxLength(100)]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }
        public int AvailableQuantity { get; set; }
        [Precision(18, 2)]
        public decimal Discount { get; set; }
        [MaxLength(100)]
        public string Specification { get; set; }

    }
}
