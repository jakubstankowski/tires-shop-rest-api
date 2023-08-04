namespace TyresShopAPI.Models
{
    public class Producer : BasicModel
    {
        public string Name { get; set; }

        public string Localization { get; set; }

        public List<Tyres> Tyres { get; set; }

        public Producer(string name, string localization)
        {
            this.Name = name;
            this.Localization = localization;
            Tyres = new List<Tyres>();
        }
    }
}
