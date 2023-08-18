using TyresShopAPI.Domain.Models.SearchCriteria;
using TyresShopAPI.Domain.Models.SearchResults;
using TyresShopAPI.Domain.Models.Tyres;
using TyresShopAPI.Models.Tyres;

namespace TyresShopAPI.Application.Interfaces
{
    public interface ITyresService
    {
        public Task AddOrUpdateTyre(TyreCreate tyreCreate);

        public Task<IEnumerable<TyreView>> GetAllTyres();

        public Task<TyreView> GetTyreBydId(int tyreId);

        public Task DeleteTyreById(int id);

        public Task<TyreSR> GetTyresBySC(TyreSC sc);

    }
}
