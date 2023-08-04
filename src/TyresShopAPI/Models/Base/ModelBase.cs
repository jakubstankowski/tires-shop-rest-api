namespace TyresShopAPI.Models.Base;

public abstract class ModelBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
}