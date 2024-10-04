using MeuBlog.Shared.Data;
using MeuBlog.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MeuBlog.Api.Controllers
{
    [Route("api/v1/meu-blog/comentarios")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComentariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IList<Comentario>>> Get([FromQuery] int? postId)
        {
            if (_context.Comentarios == null) return NotFound();
            
            return await _context.Comentarios.Include(c => c.Autor).Include(c => c.Post).Where(c => !postId.HasValue || c.PostId == postId.Value).ToListAsync();            
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Comentario>> Get(int id)
        {
            if (_context.Comentarios == null) return NotFound();

            var comentario = await _context.Comentarios.Include(c => c.Autor).Include(c => c.Post).Where(c => c.Id == id).FirstOrDefaultAsync();
            
            if (comentario == null) return NotFound();
            
            return comentario;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Post(Comentario comentario)
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null) return Unauthorized();

            if (_context.Comentarios == null) return Problem("Falha ao criar comentario", statusCode: StatusCodes.Status400BadRequest);

            var post = await _context.Posts.FindAsync(comentario.PostId);
            if (post == null) return Problem("Falha ao criar comentario", statusCode: StatusCodes.Status400BadRequest);

            var autor = await _context.Autores.FirstOrDefaultAsync(a => a.UsuarioAplicacaoId == claim.Value);
            if (autor == null) return Unauthorized();

            ModelState.Remove("DataCriacao");
            ModelState.Remove("DataAtualizacao");
            ModelState.Remove("AutorId");
            
            comentario.AutorId = autor.Id;

            if (!ModelState.IsValid)
                return ValidationProblem(
                    new ValidationProblemDetails(ModelState)
                    {
                        Title = "Ocorreram problemas de validação"
                    });

            _context.Comentarios.Add(comentario);            
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(Get), comentario.Id, comentario);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Put(int id, Comentario comentario)
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null) return Unauthorized();

            ModelState.Remove("DataCriacao");
            ModelState.Remove("DataAtualizacao");
            ModelState.Remove("AutorId");
            ModelState.Remove("PostId");

            if (!ModelState.IsValid)
                return ValidationProblem(
                    new ValidationProblemDetails(ModelState)
                    {
                        Title = "Ocorreram problemas de validação"
                    });

            if (id != comentario.Id) return BadRequest();

            var comentarioExistente = await _context.Comentarios.FindAsync(id);
            if (comentarioExistente == null) return NotFound();

            if (!comentarioExistente.PodeSermodificadoOuExcluidoPor(User)) return Unauthorized();

            comentarioExistente.Descricao = comentario.Descricao;
            _context.Update(comentarioExistente);
            await _context.SaveChangesAsync();
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Comentarios == null) return NotFound();

            var comentario = await _context.Comentarios.FindAsync(id);

            if (comentario == null) return NotFound();

            if (!comentario.PodeSermodificadoOuExcluidoPor(User)) return Unauthorized();

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComentarioExists(int id)
        {
            return (_context.Comentarios?.Any(p => p.Id == id)).GetValueOrDefault();
        }

    }
}
