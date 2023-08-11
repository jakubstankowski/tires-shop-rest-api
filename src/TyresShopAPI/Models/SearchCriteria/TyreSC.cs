namespace TyresShopAPI.Models.SearchCriteria
{
    public class TyreSC : SearchCriteria
    {
        public decimal PriceMin { get; set; } = 0.0m;
        public decimal PriceMax { get; set; } = 100000000000.00m;

        public int ProductionYearMin { get; set; } = 0;
        public int ProductionYearMax { get; set; } = int.MaxValue;

        public string Model { get; set; } = string.Empty;
    }
}
