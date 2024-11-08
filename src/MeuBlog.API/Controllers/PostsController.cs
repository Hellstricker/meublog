using MeuBlog.Shared.Data;
using MeuBlog.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MeuBlog.Api.Controllers
{
    [Authorize]
    [Route("api/v1/meu-blog/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IList<Post>>> Get()
        {
            if (_context.Posts == null) return NotFound();

            return await _context.Posts.Include(p => p.Autor).ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Post>> Get(int id)
        {
            if (_context.Posts == null) return NotFound();

            var post = await _context.Posts
                .Include(p => p.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (post == null) return NotFound();

            return post;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Post>> Post(Post post)
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null) return Unauthorized();

            if (_context.Posts == null) return Problem("Falha ao criar post", statusCode: StatusCodes.Status400BadRequest);

            var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == claim.Value);
            if (autor == null) return Unauthorized();

            ModelState.Remove("DataPublicacao");
            ModelState.Remove("DataAtualizacao");
            ModelState.Remove("AutorId");

            post.AutorId = autor.Id;            

            if (!ModelState.IsValid) return ValidationProblem(
                new ValidationProblemDetails(ModelState)
                { Title = "Ocorreram problemas de validação" }
                );
            
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(Get), post.Id, post);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Put(int id,Post post)
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null) return Unauthorized();

            if (id != post.Id) return BadRequest();

            ModelState.Remove("DataPublicacao");
            ModelState.Remove("DataAtualizacao");
            ModelState.Remove("AutorId");


            if (!ModelState.IsValid) return ValidationProblem(
                new ValidationProblemDetails(ModelState)
                { Title = "Ocorreram problemas de validação" }
                );

            var postExistente = await _context.Posts.Include(p=>p.Autor).FirstOrDefaultAsync(p=>p.Id == id);
            
            if (postExistente == null) return NotFound();
            
            if (!postExistente.PodeSermodificadoOuExcluidoPor(User)) return Unauthorized();

            postExistente.Titulo = post.Titulo;
            postExistente.Descricao = post.Descricao;
            _context.Update(postExistente);
            await _context.SaveChangesAsync();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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
            if (_context.Posts == null) return NotFound();

            var post = await _context.Posts.FindAsync(id);
            
            if (post == null) return NotFound();

            if (!post.PodeSermodificadoOuExcluidoPor(User)) return Unauthorized();

            _context.Posts.Remove(post);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return (_context.Posts?.Any(p => p.Id == id)).GetValueOrDefault();
        }
    }
}
