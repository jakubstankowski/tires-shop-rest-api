using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace TyresShopAPI.Domain.Entities.Customers
{
    public class Customer : BaseModel
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public Address Address { get; set; }
        
        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }
    }
}
