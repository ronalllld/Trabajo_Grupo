using System.ComponentModel.DataAnnotations;

namespace Empresa.Models
{
    public class Salario
    {
        [Key]

        public int idSalario { get; set; }

        public int salario { get; set; }

        public DateTime FechaInicio { get; set; }

    }

}
