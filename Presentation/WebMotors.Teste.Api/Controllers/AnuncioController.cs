using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMotors.Teste.Application.Interfaces;
using WebMotors.Teste.Domain.Entities;

namespace WebMotors.Teste.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnuncioController : ControllerBase
    {
        protected readonly IAnuncioAppService _anuncioAppService;

        public AnuncioController(IAnuncioAppService anuncioAppService)
        {
            _anuncioAppService = anuncioAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string marca, string modelo, string versao)
        {
            try
            {
                var anuncio = await _anuncioAppService.Get(new Anuncio { Marca = marca, Modelo = modelo, Versao = versao });

                return Ok(anuncio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]        
        public async Task<IActionResult> Add([FromBody] Anuncio anuncio)
        {
            try
            {
                anuncio = await _anuncioAppService.Add(anuncio);

                return Ok(anuncio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Anuncio anuncio)
        {
            try
            {
                anuncio = await _anuncioAppService.Update(anuncio);

                return Ok(anuncio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _anuncioAppService.Delete(new Anuncio { Id = id });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}