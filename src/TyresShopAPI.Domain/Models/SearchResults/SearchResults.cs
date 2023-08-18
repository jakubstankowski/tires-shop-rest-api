namespace TyresShopAPI.Domain.Models.SearchResults
{
    public class SearchResults<T>
    {
        public int CurrentPage { get; set; }

        public IEnumerable<T> Items { get; set; } = null!;

        public int TotalCount { get; set; }

    }
}
