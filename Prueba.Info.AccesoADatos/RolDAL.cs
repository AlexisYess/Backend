using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Info.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;

namespace Prueba.Info.AccesoADatos
{
    public class RolDAL
    {
        public static async Task<int> Crear(Rol pRol)
        {
            int result = 0;
            using (var bdContext = new ConexionDB())
            {
                bdContext.Add(pRol);
                result = await bdContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> Modificar(Rol pRol)
        {
            int result = 0;
            using (var bdContext = new ConexionDB())
            {
                var rol = await bdContext.Roles.FirstOrDefaultAsync(r => r.Id == pRol.Id);
                rol.Nombre = pRol.Nombre;
                rol.Descripcion = pRol.Descripcion;
                bdContext.Update(rol);
                result = await bdContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> Eliminar(Rol pRol)
        {
            int result = 0;
            using (var bdContext = new ConexionDB())
            {
                var rol = await bdContext.Roles.FirstOrDefaultAsync(r => r.Id == pRol.Id);
                bdContext.Remove(rol);
                result = await bdContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Rol> ObtenerPorId(Rol pRol)
        {
            var rol = new Rol();
            using (var bdContext = new ConexionDB())
            {
                rol = await bdContext.Roles.FirstOrDefaultAsync(r => r.Id == pRol.Id);
            }
            return rol;
        }

        public static async Task<List<Rol>> ObtenerTodos()
        {
            var roles = new List<Rol>();
            using (var bdContext = new ConexionDB())
            {
                roles = await bdContext.Roles.ToListAsync();
            }
            return roles;
        }


    }
}
