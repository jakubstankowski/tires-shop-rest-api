
using TyresShopAPI.Domain.Entities;

namespace TyresShopAPI.Domain.Models.Producer
{
    public class ProducerCreate : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

    }
}
