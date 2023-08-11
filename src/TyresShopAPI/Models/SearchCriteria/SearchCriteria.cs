using TyresShopAPI.Enums;

namespace TyresShopAPI.Models.SearchCriteria
{
    public class SearchCriteria
    {
        public int PageNumber { get; set; }

        public int RowsOnPage { get; set; }

        public string SortColumn { get; set; } = null!;

        public SortDirection SortDirection { get; set; }

        public int PrizeFrom { get; set; }

        public int PrizeTo { get; set;}

        public int DateFrom { get; set; }

        public int DateTo { get; set; }

        public string ModelName { get; set; } = string.Empty;
    }
}
