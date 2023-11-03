using System.ComponentModel.DataAnnotations;

namespace empresa1.Context
{
    public class Titulo
    {
        [Key]
        public long IdTitulo { get; set; }
        public string TITULO { get; set; }
        public string Descripcion { get; set; }


    }
}