namespace TyresShopAPI.Domain.Exceptions
{
    public sealed class TyreNotFoundException : CustomException
    {
        public int Id { get; }
        public TyreNotFoundException(int id) : base($"Tyre with ID {id} was not found")
        {
            Id = id;
        }
    }
}
