namespace TyresShopAPI.Exceptions
{
    public class DidntFindProducerAtGivenIdException : Exception
    {
        public DidntFindProducerAtGivenIdException()
        {
            
        }

        public DidntFindProducerAtGivenIdException(int producerId)
            :base(String.Format($"Didn't find Producer at given Id = {producerId}"))
        {
            
        }
    }
}
