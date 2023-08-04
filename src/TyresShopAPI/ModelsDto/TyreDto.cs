using TyresShopAPI.Models;

namespace TyresShopAPI.ModelsDto;

public class TyreDto
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string TyreType { get; set; }
    public string ManufacturerName { get; set; }
    public string ManufacturerCountry { get; set; }
    public int ProductionYear { get; set; }
    public int SizeWidth { get; set; }
    public int SizeProfile { get; set; }
    public int SizeDiameter { get; set; }
    public decimal Price { get; set; }
    
    public static TyreDto Create(Tyre tyre)
    {
        return new()
        {
            Id = tyre.Id,
            Model = tyre.Model,
            Price = tyre.Price,
            ProductionYear = tyre.ProductionYear,
            SizeWidth = tyre.SizeWidth,
            SizeProfile = tyre.SizeProfile,
            TyreType = tyre.TyreType.ToString(),
            SizeDiameter = tyre.SizeDiameter,
            ManufacturerCountry = tyre.Manufacturer?.Country ?? string.Empty,
            ManufacturerName = tyre.Manufacturer?.Name ?? string.Empty,
        };
    }
}