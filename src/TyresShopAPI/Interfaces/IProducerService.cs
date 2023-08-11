using TyresShopAPI.Models.Producer;

namespace TyresShopAPI.Interfaces
{
    public interface IProducerService
    {
        public Task AddOrUpdateProducer(ProducerCreate producerCreate);

        public Task<IEnumerable<ProducerView>> GetAllProducers();

        public Task<ProducerView> GetProducerBydId(int tyreId);

        public Task DeleteProducerById(int id);
    }
}
