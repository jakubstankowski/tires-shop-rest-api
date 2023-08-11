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
        private readonly IProducerService _service;

        public ProducerController(IProducerService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddOrUpdateProducer")]
        public async Task<IActionResult> AddOrUpdateProducer(ProducerCreate model)
        {
            try
            {
                await _service.AddOrUpdateProducer(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return Ok();
        }



        [HttpGet]
        [Route("GetProducersById/{producerId}")]
        public async Task<IActionResult> GetProducersById(int producerId)
        {
            var result = await _service.GetProducerBydId(producerId);

            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllProducers")]
        public async Task<IActionResult> GetAllProducers()
        {
            var result = await _service.GetAllProducers();

            return Ok(result);
        }



        [HttpDelete]
        [Route("DeleteProducerById/{producerId}")]
        public async Task<IActionResult> DeleteProducerById(int producerId)
        {
            try
            {
                await _service.DeleteProducerById(producerId);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }


            return Ok();
        }



    }
}
