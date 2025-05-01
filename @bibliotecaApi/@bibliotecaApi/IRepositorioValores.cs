using _bibliotecaApi.Entidades;

namespace _bibliotecaApi
{
    public interface IRepositorioValores
    {
        void InsertarValor(Valores valor);
        public IEnumerable<Valores> ObtenerValores();
    }
}
