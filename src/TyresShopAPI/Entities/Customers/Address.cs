using System.ComponentModel.DataAnnotations.Schema;
using TyresShopAPI.Models.Base;

namespace TyresShopAPI.Entities.Customers;

public class Address : ModelBase
{
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
    public string LocalNumber { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public Customer Customer { get; set; }
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
}