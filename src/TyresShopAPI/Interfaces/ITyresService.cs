using TyresShopAPI.Models.Tyres;

namespace TyresShopAPI.Interfaces
{
    public interface ITyresService
    {
        public Task AddOrUpdateTyre(TyreCreate tyreCreate);

        public Task<IEnumerable<TyreView>> GetAllTyres();

        public Task<TyreView> GetTyreBydId(int tyreId);

        public Task DeleteTyreById(int id);

    }
}
