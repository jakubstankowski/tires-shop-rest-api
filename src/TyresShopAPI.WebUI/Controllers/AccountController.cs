using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TyresShopAPI.Application.Interfaces;
using TyresShopAPI.Domain.Entities.Customers;
using TyresShopAPI.Domain.Models.Authentication;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TyresShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IIdentityService _identityService;
        private readonly ICustomerCartService _customerCartService;
        private readonly SignInManager<Customer> _signInManager;

        public AccountController(UserManager<Customer> userManager, SignInManager<Customer> signInManager, IIdentityService identityService, ICustomerCartService customerCartService)
        {
            _userManager = userManager;
            _identityService = identityService;
            _customerCartService = customerCartService;
            _signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(Register registerModel)
        {
            var isUserExist = await _userManager.FindByEmailAsync(registerModel.Email);

            if (isUserExist is not null)
            {
                return BadRequest($"Username with email {registerModel.Email} already exist");
            }

            var user = new Customer
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Email = registerModel.Email,
                UserName = registerModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            await _customerCartService.RegisterCustomerCart(user.Email);

            return new User
            {
                Token = _identityService.GenerateToken(user),
                Email = user.Email
            };

        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(Login loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user is null)
            {
                return Unauthorized();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            return new User
            {
                Token = _identityService.GenerateToken(user),
                Email = user.Email ?? string.Empty
            };
        }
    }
}
