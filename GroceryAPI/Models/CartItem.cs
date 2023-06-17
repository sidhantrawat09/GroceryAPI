using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryAPI.Models
{
    public class CartItem
    {
        public string Id { get; set; }
        public int MenuItemId { get; set; }
        [ForeignKey(nameof(MenuItemId))]
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
