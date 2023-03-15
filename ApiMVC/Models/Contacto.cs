﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ApiMVC.Models
{
    public class Contacto
    {
        [Display(Name = "idContacto")] public int idContacto { get; set; }
        [Display(Name = "nombre")] public string nombre { get; set; }
        [Display(Name = "apellido")] public string apellido { get; set; }
        [Display(Name = "direccion")] public string direccion { get; set; }
        [Display(Name = "telefono")] public string telefono { get; set; }
        [Display(Name = "estado")] public string estado { get; set; }
    }
}
