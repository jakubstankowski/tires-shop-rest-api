using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Models;
using TyresShopAPI.ModelsDto;
using TyresShopAPI.Repository;

namespace TyresShopAPI.Services;

public class TyreService : ITyreService
{
    private readonly TyreDbContext _context;

    public TyreService(TyreDbContext context)
    {
        _context = context;
    }

    public async Task<List<TyreDto>> GetAll()
    {
        return await _context.Tyres
            .Include(t => t.Manufacturer)
            .Select(t => TyreDto.Create(t))
            .ToListAsync();
    }

    public async Task<TyreDto> Get(int id)
    {
        return TyreDto.Create(await _context.Tyres.SingleOrDefaultAsync(t => t.Id == id) ?? new Tyre());
    }

    public async Task<TyreDto> Add(TyreCreateDto tyre)
    {
        var tyreToAdd = new Tyre()
        {
            IsAvailable = true,
            ManufacturerId = tyre.ManufacturerId,
            Model = tyre.Model,
            Price = tyre.Price,
            SizeDiameter = tyre.SizeDiameter,
            SizeProfile = tyre.SizeProfile,
            ProductionYear = tyre.ProductionYear,
            SizeWidth = tyre.SizeWidth,
            TyreType = tyre.TyreType
        };

        _context.Tyres.Add(tyreToAdd);
        await _context.SaveChangesAsync();
        
        return TyreDto.Create(tyreToAdd);
    }

    public async Task Remove(int id)
    {
        var tyreToDelete = await _context.Tyres.SingleOrDefaultAsync(t => t.Id == id);
        
        if (tyreToDelete != null)
        {
            _context.Tyres.Remove(tyreToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(TyreUpdateDto tyre)
    {
        var tyreToUpdate = await _context.Tyres.SingleOrDefaultAsync(t => t.Id == tyre.Id);

        if (tyreToUpdate != null)
        {
            tyreToUpdate.Model = tyre.Model;
            tyreToUpdate.TyreType = tyre.TyreType;
            tyreToUpdate.ProductionYear = tyre.ProductionYear;
            tyreToUpdate.SizeWidth = tyre.SizeWidth;
            tyreToUpdate.SizeProfile = tyre.SizeProfile;
            tyreToUpdate.SizeDiameter = tyre.SizeDiameter;
            tyreToUpdate.Price = tyre.Price;

            await _context.SaveChangesAsync();
        }
    }
}