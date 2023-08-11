using TyresShopAPI.Entities;

namespace TyresShopAPI.Models.Producer
{
    public class ProducerView:BaseModel
    {
        public string Name { get; set; }
        public string Localization { get; set; }
    }
}
