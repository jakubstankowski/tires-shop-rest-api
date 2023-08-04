using Microsoft.AspNetCore.Mvc;
using TyresShopAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TyresShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TyresController : ControllerBase
    {
        private readonly List<Tyre> tyresList = new()
        {
            new Tyre("Pirelli", "P1", 170.0m, 2022, 195, 75, 16, TyreType.Summer),
            new Tyre("Michelline", "P2", 275.0m, 2023, 180, 65, 18, TyreType.Summer),
            new Tyre("Tyro", "P3", 145.0m, 2017, 125, 35, 12, TyreType.Winter),
            new Tyre("Tyro", "P3", 145.0m, 2023, 225, 85, 19, TyreType.AllSeasons)
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
