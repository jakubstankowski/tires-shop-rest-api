namespace TyresShopAPI.Models
{
    public class Producer : BasicModel
    {
        public string Name { get; set; } = string.Empty;

        public string CountryCode { get; set; } = string.Empty;

        public List<Tyres> TyresList { get; set; } = new List<Tyres>();

        public Producer(string name, string countryCode)
        {
            Name = name;
            CountryCode = countryCode;
        }
    }
}