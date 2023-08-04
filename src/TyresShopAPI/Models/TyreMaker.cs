namespace TyresShopAPI.Models
{
    public class TyreMaker : BasicModel
    {

        public string Brand { get; set; } = string.Empty;
        public string Localization { get; set; }

        public TyreMaker(string brand, string localization)
        {
            Brand = brand;
            Localization = localization;           
        }
    }
}
