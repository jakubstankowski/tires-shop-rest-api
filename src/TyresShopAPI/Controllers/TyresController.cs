using Microsoft.AspNetCore.Mvc;
using TyresShopAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TyresShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TyresController : ControllerBase
    {
        private readonly List<Tyres> tyresList = new()
        {
            new Tyres("Pirelli", "P1"),
            new Tyres("Michelline", "P2"),
            new Tyres("Tyro", "P3")
        };

        public TyresController()
        {

        }

        [HttpGet]
        [Route("GetAllTyres")]
        public IActionResult GetAllTyres()
        {
            return Ok(tyresList.ToList());
        }

    }
}
