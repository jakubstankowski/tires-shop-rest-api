﻿using Microsoft.AspNetCore.Mvc;
using TyresShopAPI.Interfaces;
using TyresShopAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TyresShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TyresController : ControllerBase
    {
        private ITyresService _tyresService;

        public TyresController(ITyresService tyresService)
        {
            _tyresService = tyresService;
        }

        [HttpGet]
        [Route("GetAllTyres")]
        public IActionResult GetAllTyres()
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetTyre")]
        public IActionResult GetAllTyres(int tyreId)
        {
            var tyre = _tyresService.GetTyre(tyreId);
            return Ok(tyre);
        }

        [HttpPost]
        [Route("AddTyre")]
        public async Task<IActionResult> AddTyre(TyreCreate model)
        {
            try
            {
                await _tyresService.AddTyre(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return Ok();
        }

        [HttpPut]
        [Route("UpdateTyre")]
        public async Task<IActionResult> UpdateTyre(int tyreId, TyreCreate model)
        {
            _tyresService.UpdateTyre(tyreId, model);

            return Ok();
        }

        [HttpDelete]
        [Route("RemoveTyre")]
        public async Task<IActionResult> RemoveTyre(int tyreId)
        {
            _tyresService.RemoveTyre(tyreId);

            return Ok();
        }



    }
}
