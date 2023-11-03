using System.ComponentModel.DataAnnotations;

namespace Empresa.Models
{
    public class Sure
    {
        [Key]

        public int Id_Sure { get; set; }

        public string Tipe { get; set; }

        public string Import { get; set; }

        public DateTime Date_import { get; set; }
        //public int Id_seguro { get; internal set; }
    }
}
