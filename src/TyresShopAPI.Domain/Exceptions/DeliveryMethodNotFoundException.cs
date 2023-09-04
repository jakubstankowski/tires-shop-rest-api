namespace TyresShopAPI.Domain.Exceptions
{
    public class DeliveryMethodNotFoundException : CustomException
    {
        public int Id { get; }
        public DeliveryMethodNotFoundException(int id) : base($"Delivery method with ID {id} was not found")
        {
            Id = id;
        }
    }
}
