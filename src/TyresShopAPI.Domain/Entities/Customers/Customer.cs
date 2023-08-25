namespace TyresShopAPI.Domain.Entities.Customers
{
    public class Customer : BaseModel
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public CustomerAddress? Address { get; set; }
        
        public int AddressId { get; set; }
    }
}
