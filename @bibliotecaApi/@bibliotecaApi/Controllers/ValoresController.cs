using _bibliotecaApi.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace _bibliotecaApi.Controllers
{
    [ApiController]
    [Route("api/valores")]
    public class ValoresController : ControllerBase
    {
        private readonly IRepositorioValores repositorioValores;
        private readonly ServicioTransient transient1;
        private readonly ServicioTransient transient2;
        private readonly ServicioScoped scoped1;
        private readonly ServicioScoped scoped2;
        private readonly ServicioSingleton singleton1;

        public ValoresController(IRepositorioValores repositorioValores,
            ServicioTransient transient1,
            ServicioTransient transient2,
            ServicioScoped scoped1,
            ServicioScoped scoped2,
            ServicioSingleton singleton1)
        
        {
            this.repositorioValores = repositorioValores;
            this.transient1 = transient1;
            this.transient2 = transient2;
            this.scoped1 = scoped1;
            this.scoped2 = scoped2;
            this.singleton1 = singleton1;
        }

        [HttpGet("servicio-tiempo-vida")]
        public IActionResult GetServiciosTiempoDeVida()
        {
            return Ok(new
            {
                Transient = new
                {
                    transient1 = transient1.ObtenerGuid,//cada ves que recarguemos seran datos diferentes
                    transient2= transient2.ObtenerGuid
                },
                Scope = new
                {
                    Scoped1 = scoped1.ObtenerGuid, //en scope tendremos similitudes entre los dos
                    Scoped2 = scoped2.ObtenerGuid
                },
                Singleton = new
                {
                    singleton1 = singleton1.ObtenerGuid  // uno fijo amenos que reincimienos el app
                }
            });
        }


        [HttpGet]

        public IEnumerable<Valores> Get()
        {
            return repositorioValores.ObtenerValores();
        }

        [HttpPost]
        public IActionResult Post(Valores valor)
        {
            repositorioValores.InsertarValor(valor);
            return Ok();
        }
        
    }
}
