using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyresShopAPI.Domain.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }
    }
}
