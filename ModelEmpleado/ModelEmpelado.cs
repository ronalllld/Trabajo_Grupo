using System.ComponentModel.DataAnnotations;

namespace empresa1.Context
{
    public class Empelado
    {
        [Key]
        public long IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Genero { get; set; }
        public string FechaNacimiento { get; set; }
    }
}