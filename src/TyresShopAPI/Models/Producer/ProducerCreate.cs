using TyresShopAPI.Entities;

namespace TyresShopAPI.Models.Producer
{
    public class ProducerCreate : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public string Localization { get; set; } = string.Empty;

    }
}
