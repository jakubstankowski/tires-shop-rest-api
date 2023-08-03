namespace TyresShopAPI.Models
{
    public class Tyres
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = true;

        public Tyres( string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

    }
}
