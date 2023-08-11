using TyresShopAPI.Enums;

namespace TyresShopAPI.Models.SearchCriteria
{
    public class SearchCriteria
    {
        public int PageNumber { get; set; }

        public int RowsOnPage { get; set; }

        public string SortColumn { get; set; } = null!;

        public SortDirection SortDirection { get; set; }
    }
}
