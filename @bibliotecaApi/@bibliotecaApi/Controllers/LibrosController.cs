using _bibliotecaApi.Datos;
using _bibliotecaApi.Entidades;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _bibliotecaApi.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context) //ctor
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<IEnumerable<Libro>> Get()
        {

            return await context.Libros.ToListAsync();

        }
        [HttpGet("{id:int}")]

        public async Task<ActionResult<Libro>> Get(int id)
        {
            var libro = await context.Libros
                .Include(x=>x.Autor)
                .FirstOrDefaultAsync(x => x.id == id);

            if (libro == null)
            {
                return NotFound();
            }
            return libro;

        }
        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {


            var ExisteAutor = await context.Autores.AnyAsync(x => x.id == libro.AutorId);
            //nos permite conseguir el verdadero o faslo 

            if (!ExisteAutor)
            {
                ModelState.AddModelError(nameof(libro.AutorId), $"el autor  de id {libro.AutorId} no existe");
                return ValidationProblem();
            }

            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }



        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(int id, Libro libro)
        {

            if (id != libro.id)
            {

                return BadRequest("los ids deben coincidir");

            }


            var ExisteAutor = await context.Autores.AnyAsync(x => x.id == libro.AutorId);


            if (!ExisteAutor)
            {

                return BadRequest($"el autor  de id {libro.AutorId} no existe");
            }

            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();


        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult>Delete(int id)
        {
            var RegistrosBorrados = await context.Libros.Where(x=>x.id == id).ExecuteDeleteAsync();


            if (RegistrosBorrados == 0)
            {

                return BadRequest();

            }

            return Ok();
        }


    }
}




     
