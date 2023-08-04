﻿using TyresShopAPI.Models;
using TyresShopAPI.Models.Enum;

namespace TyresShopAPI.ModelsDto;

public class TyreCreateDto
{
    public string Model { get; set; }
    public decimal Price { get; set; }
    public int ProductionYear { get; set; }
    public int SizeWidth { get; set; }
    public int SizeProfile { get; set; }
    public int SizeDiameter { get; set; }
    public TyreType TyreType { get; set; }

    public int ManufacturerId { get; set; }
}