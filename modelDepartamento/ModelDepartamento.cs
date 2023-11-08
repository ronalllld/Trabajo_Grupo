using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Departamento
    {
        [Key]
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }

    }
}