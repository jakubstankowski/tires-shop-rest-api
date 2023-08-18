namespace TyresShopAPI.Domain.Entities
{
    public class Producer : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public List<Tyre> Tyres { get; set; } = new List<Tyre> { };

        public bool IsDeleted { get; set; } = false;

    }
}
