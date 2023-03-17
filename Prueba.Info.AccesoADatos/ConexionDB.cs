using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Info.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;

namespace Prueba.Info.AccesoADatos
{
    public class ConexionDB: DbContext
    {
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=info;Integrated Security=True");
        }
    }
}
