using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeuBlog.Shared.Data;
using MeuBlog.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MeuBlog.Shared.Data.Migrations;


namespace MeuBlog.Mvc.Controllers
{
    [Route("/",Order = 0)]
    [Route("meu-blog/posts")]
    [Authorize]
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [AllowAnonymous]        
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Posts.Include(p => p.Autor).OrderByDescending(p => p.DataPublicacao).ToListAsync();
            return View(await applicationDbContext);
        }


        [HttpGet("detalhes/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var post = await _context.Posts
                .Include(p => p.Autor)                
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null) return NotFound();

            if (TempData["ModelStateErrors"] is ICollection<string> modelStateErrors)
            {
                foreach (var error in modelStateErrors)
                    ModelState.AddModelError("", error);
            }

            return View(post);
        }
        [HttpGet("criar")]
        public IActionResult Create()
        {            
            return View();
        }
        
        [HttpPost("criar")]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> Create([Bind("Titulo,Descricao")] Post post)
        {   
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null) return Unauthorized();
            
            var autor = await _context.Autores.FirstOrDefaultAsync(a => a.UsuarioAplicacaoId == claim.Value);

            if (autor == null) return Unauthorized();
                        
            ModelState.Remove("DataPublicacao");
            ModelState.Remove("DataAtualizacao");            
            ModelState.Remove("AutorId");

            post.AutorId = autor.Id;


            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }            
            return View(post);
        }
        [HttpGet("editar/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var post = await _context.Posts.Include(p=>p.Autor).FirstOrDefaultAsync(p=>p.Id == id);

            if (post == null) return NotFound();
            
            if (!post.PodeSermodificadoOuExcluidoPor(User)) return Unauthorized();

            return View(post);
        }
                
        
        [ValidateAntiForgeryToken]
        [HttpPost("editar/{id:int}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao")] Post post)
        {
            if (id != post.Id)  return NotFound();

            ModelState.Remove("DataPublicacao");
            ModelState.Remove("DataAtualizacao");
            ModelState.Remove("AutorId");

            if (ModelState.IsValid)
            {
                try
                {
                    var postExistente = await _context.Posts.Include(p=>p.Autor).FirstOrDefaultAsync(p=>p.Id == id);
                    if (postExistente == null)  return NotFound();
                    if (!postExistente.PodeSermodificadoOuExcluidoPor(User)) return Unauthorized();

                    postExistente.Titulo = post.Titulo;
                    postExistente.Descricao = post.Descricao;
                    _context.Update(postExistente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { post.Id });
            }
        
            return View(post);
        }


        [HttpGet("excluir/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            
            var post = await _context.Posts
                .Include(p => p.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (post == null) return NotFound();

            if (!post.PodeSermodificadoOuExcluidoPor(User)) return Unauthorized();

            return View(post);
        }

        
        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {           
            var post = await _context.Posts.FindAsync(id);

            if (post == null) return NotFound();

            if (!post.PodeSermodificadoOuExcluidoPor(User)) return Unauthorized();

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
