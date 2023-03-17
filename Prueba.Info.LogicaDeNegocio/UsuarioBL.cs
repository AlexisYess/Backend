using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Info.EntidadesDeNegocio;
using Prueba.Info.AccesoADatos;

namespace Prueba.Info.LogicaDeNegocio
{
    public class UsuarioBL
    {
        public async Task<int> Crear(Usuario pUsuario)
        {
            return await UsuarioDAL.Crear(pUsuario);
        }

        public async Task<int> Modificar(Usuario pUsuario)
        {
            return await UsuarioDAL.Modificar(pUsuario);
        }

        public async Task<int> Eliminar(Usuario pUsuario)
        {
            return await UsuarioDAL.Eliminar(pUsuario);
        }

        public async Task<Usuario> ObtenerPorId(Usuario pUsuario)
        {
            return await UsuarioDAL.ObtenerPorId(pUsuario);
        }

        public async Task<List<Usuario>> ObtenerTodos()
        {
            return await UsuarioDAL.ObtenerTodos();
        }
    }
}
