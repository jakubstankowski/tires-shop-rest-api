using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Interfaces;
using TyresShopAPI.Models;

namespace TyresShopAPI.Services
{
    public class TyresService : ITyresService
    {
        private IContext _context;

        public TyresService(IContext context)
        {
            _context = context;
        }

        public async Task AddTyre(TyreCreate tyreCreate)
        {
            var dbTyre = new Tyre();

            dbTyre.ProducerId = tyreCreate.ProducerId;
            dbTyre.Price = tyreCreate.Price;
            dbTyre.TyresType = tyreCreate.TyresType;
            dbTyre.Model = tyreCreate.Model;
            dbTyre.ProductionYear = tyreCreate.ProductionYear;
            dbTyre.SizeProfile = tyreCreate.SizeProfile;
            dbTyre.SizeWidth = tyreCreate.SizeWidth;
            dbTyre.SizeDiameter = tyreCreate.SizeDiameter;

            _context.Tyres.Add(dbTyre);

            await _context.SaveChangesAsync();
        }

        public async Task<TyreCreate> GetTyre(int tyreId)
        {
            Tyre tyre = _context.Tyres.FirstOrDefault(x=>x.Id==tyreId);

            return new TyreCreate()
            {
                ProducerId = tyre.ProducerId,
                Model = tyre.Model,
                Price = tyre.Price,
                ProductionYear = tyre.ProductionYear,
                SizeWidth = tyre.SizeWidth,
                SizeProfile = tyre.SizeProfile,
                SizeDiameter = tyre.SizeDiameter,
                TyresType = tyre.TyresType
            };
        }

        public async Task RemoveTyre(int tyreId)
        {
            _context.Tyres.Remove(_context.Tyres.FirstOrDefault(x=>x.Id==tyreId));

            await _context.SaveChangesAsync();
        }

        public async Task UpdateTyre(int tyreId,TyreCreate tyreCreate)
        {
            var dbTyre = new Tyre();

            dbTyre.ProducerId = tyreCreate.ProducerId;
            dbTyre.Price = tyreCreate.Price;
            dbTyre.TyresType = tyreCreate.TyresType;
            dbTyre.Model = tyreCreate.Model;
            dbTyre.ProductionYear = tyreCreate.ProductionYear;
            dbTyre.SizeProfile = tyreCreate.SizeProfile;
            dbTyre.SizeWidth = tyreCreate.SizeWidth;
            dbTyre.SizeDiameter = tyreCreate.SizeDiameter;

            _context.Tyres.Update(_context.Tyres.FirstOrDefault(x=>x.Id==tyreId));

            await _context.SaveChangesAsync();
        }
    }
}
