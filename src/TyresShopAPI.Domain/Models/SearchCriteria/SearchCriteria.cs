
using TyresShopAPI.Domain.Enums;

namespace TyresShopAPI.Domain.Models.SearchCriteria
{
    public class SearchCriteria
    {
        public int PageNumber { get; set; }

        public int RowsOnPage { get; set; }

        public SortDirection SortDirection { get; set; }
    }
}
