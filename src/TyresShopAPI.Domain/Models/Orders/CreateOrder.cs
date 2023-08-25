using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyresShopAPI.Domain.Models.Orders
{
    public class CreateOrder
    {
        public int CartId { get; set; }
        public int DeliveryMethodId { get; set; }
    }
}
