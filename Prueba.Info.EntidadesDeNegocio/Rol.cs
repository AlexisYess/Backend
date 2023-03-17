using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Info.EntidadesDeNegocio
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Nombre { get; set; }

        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        [Required(ErrorMessage = "Descripcion es obligatorio")]
        public string Descripcion { get; set; }
    }
}

