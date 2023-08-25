﻿namespace TyresShopAPI.Domain.Entities.OrderAggregate
{
    public class DeliveryMethod
    {
        public string ShortName { get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
