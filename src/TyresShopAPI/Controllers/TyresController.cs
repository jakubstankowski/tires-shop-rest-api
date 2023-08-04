using Microsoft.AspNetCore.Mvc;
using TyresShopAPI.ModelsDto;
using TyresShopAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TyresShopAPI.Controllers
{
    [Route("api/tyres")]
    [ApiController]
    public class TyresController : ControllerBase
    {
        private readonly ITyreService _tyreService;


        public TyresController(ITyreService tyreService)
        {
            _tyreService = tyreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tyres = await _tyreService.GetAll();
                return Ok(tyres);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var tyres = await _tyreService.Get(id);
                return Ok(tyres);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(TyreCreateDto tyreCreateDto)
        {
            try
            {
                var createdTyre = await _tyreService.Add(tyreCreateDto);
                return Ok(createdTyre);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tyreService.Remove(id);
                return Ok();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(TyreUpdateDto tyreUpdate)
        {
            try
            {
                await _tyreService.Update(tyreUpdate);
                return Ok();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
        }
    }
}
