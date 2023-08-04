using System.ComponentModel.DataAnnotations.Schema;
using TyresShopAPI.Models.Base;

namespace TyresShopAPI.Entities.Customers;

public class Customer : ModelBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    
    [ForeignKey(nameof(Address))]
    public int AddressId { get; set; }
}