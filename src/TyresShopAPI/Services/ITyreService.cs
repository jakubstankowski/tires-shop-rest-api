using TyresShopAPI.Models;
using TyresShopAPI.ModelsDto;

namespace TyresShopAPI.Services;

public interface ITyreService
{
    Task<List<TyreDto>> GetAll();
    Task<TyreDto> Get(int id);
    Task<TyreDto> Add(TyreCreateDto tyre);
    Task Remove(int id);
    Task Update(TyreUpdateDto tyre);
}