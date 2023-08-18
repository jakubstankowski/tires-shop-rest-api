using TyresShopAPI.Domain.Entities;

namespace TyresShopAPI.Domain.Models.SearchResults
{
    public class TyreSR : SearchResults<TyreSR.Item>
    {
        public class Item : BaseModel
        {
            public string ProducerName { get; set; } = string.Empty;

            public string Model { get; set; } = string.Empty;

            public decimal Price { get; set; }

            public int ProductionYear { get; set; }

            public string TyresTypeName { get; set; } = string.Empty;
        }

    }
}
