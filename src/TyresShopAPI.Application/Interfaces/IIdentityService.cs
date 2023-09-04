using Microsoft.AspNetCore.Identity;

namespace TyresShopAPI.Application.Interfaces
{
    public interface IIdentityService
    {
        public string GenerateToken(IdentityUser user);

        public Task<bool> IsCustomerExist(string customerId);
    }
}
