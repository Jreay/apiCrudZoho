using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ApiMVC.Models
{
    public class Empresa
    {
        [Display(Name = "idEmpresa")] public int idEmpresa { get; set; }
        [Display(Name = "nombre")] public string nombre { get; set; }
    }
}
