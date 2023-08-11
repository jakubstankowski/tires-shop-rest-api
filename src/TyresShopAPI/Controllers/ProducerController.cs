using Microsoft.AspNetCore.Mvc;
using TyresShopAPI.Interfaces;
using TyresShopAPI.Models.Producer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TyresShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
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
            var result = await _producerService.GetAllProducers();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetProducerById/{producerId}")]
        public async Task<IActionResult> GeProducerById(int producerId)
        {
            var result = await _producerService.GetProducerBydId(producerId);

            return Ok(result);
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
