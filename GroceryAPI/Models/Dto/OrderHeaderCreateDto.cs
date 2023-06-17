using System.ComponentModel.DataAnnotations;

namespace GroceryAPI.Models.Dto
{
    public class OrderHeaderCreateDto
    {
        public string ApplicationUserId { get; set; }
        public double OrderTotal { get; set; }

        public string Status { get; set; }
        public int TotalItems { get; set; }

        public IEnumerable<OrderDetailsCreateDTO> OrderDetailsDTO { get; set; }
    }
}
