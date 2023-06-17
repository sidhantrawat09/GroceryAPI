using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GroceryAPI.Models.Dto
{
    public class MenuItemCreateDto
    {

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        [Required]
        [StringLength(100)]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        public IFormFile File { get; set; }
        public int AvailableQuantity { get; set; }
        [Precision(18, 2)]
        public decimal Discount { get; set; }
        [StringLength(100)]
        public string Specification { get; set; }
    }
}
