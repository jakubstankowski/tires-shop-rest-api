using TyresShopAPI.Models;

namespace TyresShopAPI.Interfaces
{
    public interface ITyresService
    {
        public Task AddTyre(TyreCreate tyreCreate);

        Task<TyreCreate> GetTyre(int tyreId);

        Task RemoveTyre(int tyreId);

        Task UpdateTyre(int tyreId, TyreCreate tyreCreate);

    }
}
