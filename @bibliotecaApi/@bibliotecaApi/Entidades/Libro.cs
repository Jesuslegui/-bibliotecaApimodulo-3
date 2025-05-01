using System.ComponentModel.DataAnnotations;

namespace _bibliotecaApi.Entidades
{
    public class Libro
    {
        public int id{ get; set; }
        [Required]
        public required String Titulo{ get; set; }
        public int AutorId { get; set; }
        public Autor? Autor{ get; set; }

    }
}
