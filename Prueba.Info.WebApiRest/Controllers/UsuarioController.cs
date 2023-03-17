using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prueba.Info.EntidadesDeNegocio;
using Prueba.Info.LogicaDeNegocio;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba.Info.WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private UsuarioBL usuarioBL = new UsuarioBL();

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await usuarioBL.ObtenerTodos();
        }

        [HttpGet("{id}")]
        public async Task<Usuario> Get(int id)
        {
            Usuario usuario = new Usuario();
            usuario.Id = id;
            return await usuarioBL.ObtenerPorId(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                await usuarioBL.Crear(usuario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pUsuario)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strUsuario = JsonSerializer.Serialize(pUsuario);
            Usuario usuario = JsonSerializer.Deserialize<Usuario>(strUsuario, option);
            if (usuario.Id == id)
            {
                await usuarioBL.Modificar(usuario);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Id = id;
                await usuarioBL.Eliminar(usuario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
