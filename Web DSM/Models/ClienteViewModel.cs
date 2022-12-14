using Práctica3GenNHibernate.CEN.Práctica3;
using Práctica3GenNHibernate.EN.Práctica3;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_DSM.Models
{
    public class ClienteViewModel : RegisterViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "Género musical favorito")]
        public string Genero { get; set; }

        public int Puntos { get; set; }
    }

}