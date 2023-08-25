﻿namespace TyresShopAPI.Domain.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
    }
}
