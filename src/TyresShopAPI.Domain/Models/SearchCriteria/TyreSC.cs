using TyresShopAPI.Domain.Enums;

namespace TyresShopAPI.Domain.Models.SearchCriteria
{
    public class TyreSC : SearchCriteria
    {
        public TyreSortColumns? SortColumn { get; set; } = null;

        public string? Model { get; set; } = null;

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }

        public int? ProductionYearFrom { get; set; }

        public int? ProductionYearTo { get; set; }
    }
}
