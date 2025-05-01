using _bibliotecaApi.Datos;
using _bibliotecaApi.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _bibliotecaApi.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<AutoresController> logger;

        public AutoresController(ApplicationDbContext context, ILogger<AutoresController>logger)
        {
            this.context = context;
            this.logger = logger;
        }
        [HttpGet("/listado-de-autores")]//listado de autores
        [HttpGet]//api/autores
        public async Task<IEnumerable<Autor>> Get()
        {
            logger.LogInformation("Obteniendo  el listado de autores");
            /*logger.LogCritical("Obteniendo  el listado de autores");
            logger.LogError("Obteniendo  el listado de autores");
            logger.LogWarning("Obteniendo  el listado de autores");
            logger.LogTrace("Obteniendo  el listado de autores");*/
            return await context.Autores.ToListAsync();
        }


        [HttpGet("{id:int}")]//api/autores/id 1 2 3 4 5 6 7 8 9  etc
                             //con el bol seria
                            //api/autores/id?incluirLibros=true|faslse
        public async Task<ActionResult<Autor>> Get([FromRoute]int id,[FromHeader]bool incluirLibros)
        {

            var autor = await context.Autores
                .Include(x=>x.Libros)
                .FirstOrDefaultAsync(x => x.id == id);
            if(autor is null)
            {

                return NotFound();

            }

            return autor;
        }

        [HttpGet("{nombre:alpha}")]////api/autores/felipe
        public async Task<IEnumerable<Autor>> Get(String nombre)
        {
            return await context.Autores.Where(x=>x.nombre.Contains(nombre)).ToListAsync();
        }



        //[HttpGet("{parametro1}/{parametro2?}")] //api/autores/felipe/gavilan

        //public ActionResult get(string parametro1, string parametro2 = "valor por defecto")
       // {
       //   return Ok(new {parametro1 ,parametro2});
       //}
       

        [HttpPost]

        public async Task<ActionResult> Post([FromBody]Autor autor)////PROGRAMACION ASINCROMA 

        {
            context.Add(autor);
            await context.SaveChangesAsync();// este await permite lanzar esta operacion que es mandar el insert para insertar la data a la tabla de autores
            return Ok();

        }
        [HttpPut("{id:int}")] // urel api/autores/id
        public async Task<ActionResult>Put(int id,Autor autor)
        {
            if (id !=autor.id)
            {

                return BadRequest("los Ids deben coincidir");

            }

            context.Update(autor);
            await context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var RegistrosBorrados= await context.Autores.Where(x => x.id == id).ExecuteDeleteAsync();


            if (RegistrosBorrados== 0)
            {

                return NotFound();

            }

            return Ok();
        }
        
    }
}
