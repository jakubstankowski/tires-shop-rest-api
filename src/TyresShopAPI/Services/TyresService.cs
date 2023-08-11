using TyresShopAPI.Interfaces;
using TyresShopAPI.Entities;
using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Models.Tyres;
using TyresShopAPI.Models.SearchResults;
using TyresShopAPI.Models.SearchCriteria;
using TyresShopAPI.Enums;
using TyresShopAPI.Exceptions;

namespace TyresShopAPI.Services
{
    public class TyresService : BaseService, ITyresService
    {
        private readonly ILogger<TyresService> _logger;

        public TyresService(IContext context, ILogger<TyresService> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task AddOrUpdateTyre(TyreCreate model)
        {
            var dbTyre = new Tyre();

            if (model.Id > 0)
            {
                dbTyre = await _context.Tyres.SingleAsync(c => c.Id == model.Id);
            }


            dbTyre.ProducerId = model.ProducerId;
            dbTyre.Price = model.Price;
            dbTyre.TyresType = model.TyresType;
            dbTyre.Model = model.Model;
            dbTyre.ProductionYear = model.ProductionYear;
            dbTyre.SizeProfile = model.SizeProfile;
            dbTyre.SizeWidth = model.SizeWidth;
            dbTyre.SizeDiameter = model.SizeDiameter;

            if (model.Id == 0)
            {
                _context.Tyres.Add(dbTyre);
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation("Tyre success add or update");
        }

        public async Task<TyreView> GetTyreBydId(int tyreId)
        {
            var result = await _context.Tyres
                .Where(x => x.IsAvailable && x.Id == tyreId && !x.IsDeleted)
                .Select(x => new TyreView()
                {
                    Id = x.Id,
                    Model = x.Model,
                    ProducerName = x.Producer.Name,
                    ProductionYear = x.ProductionYear,
                    TyresTypeName = x.TyresType.ToString(),
                    Price = x.Price
                }).SingleOrDefaultAsync();

            if (result == null)
            {
                _logger.LogInformation($"Tyre with id {tyreId} not found");
                throw new TyreNotFoundException(tyreId);
            }

            return result;
        }

        public async Task<IEnumerable<TyreView>> GetAllTyres()
        {
            return await _context.Tyres
                .Where(x => x.IsAvailable && !x.IsDeleted)
                .Select(x => new TyreView()
                {
                    Id = x.Id,
                    Model = x.Model,
                    ProducerName = x.Producer.Name,
                    ProductionYear = x.ProductionYear,
                    TyresTypeName = x.TyresType.ToString(),
                    Price = x.Price
                }).ToListAsync();
        }

        public async Task DeleteTyreById(int tyreId)
        {
            var tyre = await _context.Tyres.Where(x => x.Id == tyreId).SingleOrDefaultAsync();

            if (tyre == null)
            {
                _logger.LogInformation($"Tyre with id {tyreId} not found");
                throw new TyreNotFoundException(tyreId);
            }

            tyre.IsDeleted = true;

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Tyre with id {tyreId} success delete");
        }

        public async Task<TyreSR> GetTyresBySC(TyreSC sc)
        {
            var query = _context.Tyres
               .Where(x => x.IsAvailable && !x.IsDeleted)
               .Select(x => new TyreSR.Item()
               {
                   Id = x.Id,
                   Model = x.Model,
                   ProducerName = x.Producer.Name,
                   ProductionYear = x.ProductionYear,
                   TyresTypeName = x.TyresType.ToString(),
                   Price = x.Price
               });

            if (!string.IsNullOrWhiteSpace(sc.Model))
            {
                query = query.Where(x => x.Model.ToLower() != null && x.Model.Contains(sc.Model.Trim().ToLower()));
            }

            if (sc.PriceFrom != null && sc.PriceFrom > 0)
            {
                query = query.Where(x => x.Price >= sc.PriceFrom);
            }

            if (sc.PriceTo != null && sc.PriceTo > 0)
            {
                query = query.Where(x => x.Price <= sc.PriceTo);
            }

            switch (sc.SortColumn)
            {
                case TyreColumns.Id:
                    query = query.OrderBy(x => x.Id);
                    break;
                case TyreColumns.Model:
                    query = query.OrderBy(x => x.Model);
                    break;
                case TyreColumns.ProducerName:
                    query = query.OrderBy(x => x.ProducerName);
                    break;
                case TyreColumns.ProductionYear:
                    query = query.OrderBy(x => x.ProductionYear);
                    break;
                case TyreColumns.TyresTypeNane:
                    query = query.OrderBy(x => x.TyresTypeName);
                    break;
                case TyreColumns.Price:
                    query = query.OrderBy(x => x.Price);
                    break;
                default:
                    query = query.OrderBy(x => x.Id);
                    break;
            }

            if (sc.SortDirection == SortDirection.Descending)
            {
                query = query.OrderByDescending(x => x.Id);
            }

            var result = new TyreSR
            {
                CurrentPage = sc.PageNumber,
                Items = query is not null ? await query.Skip((sc.PageNumber - 1) * sc.RowsOnPage).Take(sc.RowsOnPage).ToListAsync() : Enumerable.Empty<TyreSR.Item>(),
                TotalCount = query is not null ? query.Count() : 0
            };

            return result;
        }
    }
}
