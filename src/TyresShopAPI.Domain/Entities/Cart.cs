using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresShopAPI.Domain.Enums;

namespace TyresShopAPI.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserMail { get; set; }
        public decimal PriceTotal { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
        public OrderStatus OrderStatus { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
