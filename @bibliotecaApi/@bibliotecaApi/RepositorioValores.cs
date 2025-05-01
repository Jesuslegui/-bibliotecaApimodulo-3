using _bibliotecaApi.Entidades;

namespace _bibliotecaApi
{
    public class RepositorioValores :IRepositorioValores
    {
        public void InsertarValor(Valores valor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Valores> ObtenerValores()
        {
            return new List<Valores>
            {
                new Valores{id=1, Nombre="valores 1"},
                new Valores{id=1, Nombre="valores 2"}
            };
        }
    }
}
