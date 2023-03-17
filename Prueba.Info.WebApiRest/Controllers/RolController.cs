using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Prueba.Info.LogicaDeNegocio;
using Prueba.Info.EntidadesDeNegocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba.Info.WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolController : ControllerBase
    {
        private RolBL rolBL = new RolBL();

        [HttpGet]
        public async Task<IEnumerable<Rol>> Get()
        {
            return await rolBL.ObtenerTodos();
        }

        [HttpGet("{id}")]
        public async Task<Rol> Get(int id)
        {
            Rol rol = new Rol();
            rol.Id = id;
            return await rolBL.ObtenerPorId(rol);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Rol rol)
        {
            try
            {
                await rolBL.Crear(rol);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Rol rol)
        {

            if (rol.Id == id)
            {
                await rolBL.Modificar(rol);
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
                Rol rol = new Rol();
                rol.Id = id;
                await rolBL.Eliminar(rol);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}