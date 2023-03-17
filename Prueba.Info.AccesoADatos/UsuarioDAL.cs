using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Info.EntidadesDeNegocio;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Prueba.Info.AccesoADatos
{
   public class UsuarioDAL
    {
        public static async Task<int> Crear(Usuario pUsuario)
        {
            int result = 0;
            using (var DbContext = new ConexionDB())
            {
                {
                    DbContext.Add(pUsuario);
                    result = await DbContext.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<int> Modificar(Usuario pUsuario)
        {
            int result = 0;
            using (var DbContext = new ConexionDB())
            {
                {
                    var usuario = await DbContext.Usuarios
                        .FirstOrDefaultAsync(u => u.Id == pUsuario.Id);

                    usuario.IdRol= pUsuario.IdRol;
                    usuario.Nombre = pUsuario.Nombre;
                    usuario.Correo = pUsuario.Correo;
                    usuario.Contraseña = pUsuario.Contraseña;

                    DbContext.Update(usuario);
                    result = await DbContext.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<int> Eliminar(Usuario pUsuario)
        {
            int result = 0;
            using (var DbContext = new ConexionDB())
            {
                var usuario = await DbContext.Usuarios
                    .FirstOrDefaultAsync(u => u.Id == pUsuario.Id);
                DbContext.Remove(usuario);
                result = await DbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Usuario> ObtenerPorId(Usuario pUsuario)
        {
            var usuario = new Usuario();
            using (var DbContext = new ConexionDB())
            {
                usuario = await DbContext.Usuarios
                    .FirstOrDefaultAsync(u => u.Id == pUsuario.Id);
            }
            return usuario;
        }

        public static async Task<List<Usuario>> ObtenerTodos()
        {
            var usuarios = new List<Usuario>();
            using (var DbContext = new ConexionDB())
            {
                usuarios = await DbContext.Usuarios.ToListAsync();
            }
            return usuarios;
        }

    }
}
