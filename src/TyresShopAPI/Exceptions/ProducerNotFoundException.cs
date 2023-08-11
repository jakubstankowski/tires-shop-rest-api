namespace TyresShopAPI.Exceptions
{
    public class ProducerNotFoundException : CustomException
    {
        public int Id { get; }
        public ProducerNotFoundException(int id) : base($"Producer with ID {id} was not found")
        {
            Id = id;
        }
    }
}
