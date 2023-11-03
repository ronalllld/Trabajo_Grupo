using System.ComponentModel.DataAnnotations;

namespace empresa1.Context
{
    public class Departamento
    {
        [Key]
        public long IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }


    }
}