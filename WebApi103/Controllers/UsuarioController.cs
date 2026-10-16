using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi103.dto;
using WebApi103.Services.Interfaces;

namespace WebApi103.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioservice _usuarioService;

        public UsuarioController(IUsuarioservice usuarioservice)
        {
            _usuarioService = usuarioservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _usuarioService.ObtenerUsuario();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ById(int id)
        {
            var response = await _usuarioService.ById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] usuarioDto i)
        {

            var result = await _usuarioService.Create(i);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] usuarioDto request)
        {
            var result = await _usuarioService.Update(id, request);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _usuarioService.Delete(id);
            return Ok(result);
        }
    }
}