using _bibliotecaApi.Entidades;

namespace _bibliotecaApi
{
    public class RepositorioValoresOracle:IRepositorioValores
    {
        private List<Valores> _valores;
        public RepositorioValoresOracle()
        {
          _valores = new List<Valores>
          { new Valores{id=3,Nombre ="valor 1 Oracle"},
            new Valores{id=4,Nombre ="valor 2 Oracle"},
            new Valores{id=5,Nombre ="valor 3 Oracle"}
          };
        }
        public IEnumerable<Valores>ObtenerValores()
        {
            return _valores;      
        }
        public void InsertarValor(Valores valor)
        {
            _valores.Add(valor);
        }
    }
}
