using System.ComponentModel.DataAnnotations;
using _bibliotecaApi.Validaciones;

namespace _bibliotecaApi.Entidades
{
    public class Autor
    {
        public int id { get; set; }
        [Required(ErrorMessage ="el campo {0} es requerido")]// si me envian un autor  desde un cliente nesesaria mente debe tener un nombre si no tiene puede rechazar la peticion
        [StringLength (15,ErrorMessage ="el campo {0} debe tener {1} caracteres o menos")]  // nos limita que el maximo sea (NUM) en este nos da 15 el limite
        [PrimeraLetraMayuscula]
        public required string nombre { get; set; } // nose le puede poner nulo por required
        public List<Libro> Libros { get; set; } = new List<Libro>();


        /*
        //ejemplos de uso 

        //[Range(18, 120)]// va a tener un limire de 18 a 20 cuando uses post
        //public int Edad { get; set; }

        //[CreditCard] // verifica que la targeta sea valida de 15 digitos 
        public string? TarjetaDeCredito { get; set; }


        [Url]// RETIFICA LA URL QUE SEA CORRECTA TODO ES POStMAN
        public string? Url { get; set; }
        */
    }


}
