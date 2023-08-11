using Microsoft.AspNetCore.Mvc;
using TyresShopAPI.Interfaces;
using TyresShopAPI.Models.Producer;
using TyresShopAPI.Models.Tyres;
using TyresShopAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TyresShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService service)
        {
            _producerService = service;
        }

        [HttpPost]
        [Route("AddOrUpdateProducer")]
        public async Task<IActionResult> AddOrUpdateProducer(ProducerCreate model)
        {
            try
            {
                await _producerService.AddOrUpdateProducer(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return Ok();
        }

        [HttpGet]
        [Route("GetAllProducers")]
        public async Task<IActionResult> GetAllProducers()
        {          
            return Ok(await _producerService.GetAllProducer());
        }

        [HttpGet]
        [Route("GetProducerById/{producerId}")]
        public async Task<IActionResult> GetProducerById(int producerId)
        {
            return Ok(await _producerService.GetProducerById(producerId));
        }

        [HttpDelete]
        [Route("DeleteProducerById/{producerId}")]
        public async Task<IActionResult> DeleteProducerById(int producerId)
        {
            try
            {
                await _producerService.DeleteProducerById(producerId);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }


            return Ok();
        }
    }
}
