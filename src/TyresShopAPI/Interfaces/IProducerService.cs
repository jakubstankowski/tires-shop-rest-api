using TyresShopAPI.Models.Producer;

namespace TyresShopAPI.Interfaces
{
    public interface IProducerService
    {
        public Task AddOrUpdateProducer(ProducerCreate producerCreate);
        Task<IEnumerable<ProducerCreate>> GetAllProducer();
        Task<ProducerCreate> GetProducerById(int producerId);
        Task DeleteProducerById(int id);
    }
}
