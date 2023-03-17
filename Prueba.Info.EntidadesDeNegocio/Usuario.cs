using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Info.EntidadesDeNegocio
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rol")]
        [Required(ErrorMessage = "Rol es obligatorio")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage ="Nombre es Obligatorio")]
        public string Nombre { get; set; }
        
        [StringLength(30)]
        [Required(ErrorMessage ="Correo es obligatorio")]
        public string Correo { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Contraseña es obligatorio")]
        public string Contraseña { get; set; }


        public Rol Rol { get; set; }

    }
}
