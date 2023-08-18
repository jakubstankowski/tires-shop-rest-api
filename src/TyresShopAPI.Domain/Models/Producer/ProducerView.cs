
using TyresShopAPI.Domain.Entities;

namespace TyresShopAPI.Domain.Models.Producer
{
    public class ProducerView : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public string Localization { get; set; } = string.Empty;
    }
}
