using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Domain.Entities.Customers;

namespace TyresShopAPI.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private IConfiguration _config;
        private readonly UserManager<Customer> _userManager;

        public IdentityService(IConfiguration config, UserManager<Customer> userManager)
        {
            _config = config;
           _userManager = userManager;
        }

        public string GenerateToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? string.Empty));

            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> IsCustomerExist(string customerId)
        {
            var result = await _userManager.FindByIdAsync(customerId);

            if (result  is null)
            {
                throw new Exception();
            }

            return true;
        }
    }
}
