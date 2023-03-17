using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Info.EntidadesDeNegocio;
using Prueba.Info.AccesoADatos;

namespace Prueba.Info.LogicaDeNegocio
{
    public class RolBL
    {
        public async Task<int> Crear(Rol pRol)
        {
            return await RolDAL.Crear(pRol);
        }

        public async Task<int> Modificar(Rol pRol)
        {
            return await RolDAL.Modificar(pRol);
        }

        public async Task<int> Eliminar(Rol pRol)
        {
            return await RolDAL.Eliminar(pRol);
        }

        public async Task<Rol> ObtenerPorId(Rol pRol)
        {
            return await RolDAL.ObtenerPorId(pRol);
        }

        public async Task<List<Rol>> ObtenerTodos()
        {
            return await RolDAL.ObtenerTodos();
        }
    }
}
