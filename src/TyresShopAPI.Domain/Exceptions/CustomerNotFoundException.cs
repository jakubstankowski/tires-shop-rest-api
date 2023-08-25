namespace TyresShopAPI.Domain.Exceptions
{
    public sealed class CustomerNotFoundException : CustomException
    {
        public string Id { get; set; }
        public CustomerNotFoundException(string id) : base($"Customer with ID {id} was not found")
        {
            Id = id;
        }
    }
}
