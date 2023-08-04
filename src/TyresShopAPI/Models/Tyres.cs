namespace TyresShopAPI.Models
{
    public class Tyres : BasicModel
    {
        public string Model { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = true;

        public decimal Price { get; set; }

        public int ProductionYear { get; set; }

        public int SizeWidth { get; set; }

        public int SizeProfile { get; set; }

        public int SizeDiameter { get; set; }

        public TyresType TyresType { get; set; }

        public Producer Producer { get; set; }

        public Tyres(string model, decimal price, int productionYear,
            int sizeWidth, int sizeProfile, int sizeDiameter, TyresType tyresType, Producer producer)
        {
            Model = model;
            Price = price;
            ProductionYear = productionYear;
            SizeWidth = sizeWidth;
            SizeProfile = sizeProfile;
            SizeDiameter = sizeDiameter;
            TyresType = tyresType;
            Producer = producer;
        }

    }
}
