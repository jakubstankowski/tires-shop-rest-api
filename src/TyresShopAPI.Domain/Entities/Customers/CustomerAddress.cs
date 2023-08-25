namespace TyresShopAPI.Domain.Entities.Customers
{
    public class CustomerAddress : BaseModel
    {
        public string Street { get; set; } = string.Empty;

        public double HomeNumber { get; set; }

        public string City { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public Customer Customer { get; set; }

        public string CustomerId { get; set; }
    }
}
