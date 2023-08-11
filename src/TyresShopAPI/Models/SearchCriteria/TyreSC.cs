using TyresShopAPI.Enums;

namespace TyresShopAPI.Models.SearchCriteria
{
    public class TyreSC : SearchCriteria
    {
        public TyreColumns? SortColumn { get; set; } = null;

        public string? Model { get; set; } = null;

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }

        public int? ProductionYearFrom { get; set; }

        public int? ProductionYearTo { get; set; }
    }
}
