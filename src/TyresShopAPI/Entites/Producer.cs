﻿namespace TyresShopAPI.Entities
{
    public class Producer : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public string Localization { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }

        public List<Tyre> Tyres { get; set; } = new List<Tyre> { };

    }
}
