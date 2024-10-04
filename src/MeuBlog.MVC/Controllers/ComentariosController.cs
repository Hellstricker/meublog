using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeuBlog.Shared.Data;
using MeuBlog.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MeuBlog.Mvc.Controllers
{
    [Authorize]
    [Route("meu-blog/comentarios")]
    public class ComentariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComentariosController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpPost("criar")]        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostId,Descricao,AutorId,DataCriacao,DataAtualizacao")] Comentario comentario)
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null) return Unauthorized();

            var autor = await _context.Autores.FirstOrDefaultAsync(a => a.UsuarioAplicacaoId == claim.Value);

            if (autor == null) return NotFound();

            comentario.AutorId = autor.Id;

            ModelState.Remove("DataCriacao");
            ModelState.Remove("DataAtualizacao");
            ModelState.Remove("AutorId");

            if (ModelState.IsValid)
            {
                _context.Add(comentario);
                await _context.SaveChangesAsync();                
            }
            else
            {
                TempData["ModelStateErrors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }

            return RedirectToAction("Details", "Posts", new { id = comentario.PostId });

            //return View(comentario);
        }

        [HttpGet("editar/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var comentario = await _context.Comentarios.Include(c => c.Autor).FirstOrDefaultAsync(c => c.Id == id);
            
            if (comentario == null) return NotFound();

            if (!comentario.PodeSermodificadoOuExcluidoPor(User)) return Unauthorized();

            return View(comentario);
        }
                
        [HttpPost("editar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PostId,Descricao,AutorId,DataCriacao,DataAtualizacao")] Comentario comentario)
        {
            if (id != comentario.Id) return NotFound();
                        
            ModelState.Remove("DataCriacao");
            ModelState.Remove("DataAtualizacao");
            ModelState.Remove("PostId");
            ModelState.Remove("AutorId");
            
            if (ModelState.IsValid)
            {
                try
                {
                    var comentarioExistente = await _context.Comentarios.Include(c=>c.Autor).FirstOrDefaultAsync(c=>c.Id == id);
                    if (comentarioExistente == null) return NotFound();

                    if (!comentarioExistente.PodeSermodificadoOuExcluidoPor(User)) return Unauthorized();

                    comentarioExistente.Descricao = comentario.Descricao;
                    _context.Update(comentarioExistente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Posts", new { id = comentarioExistente.PostId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioExists(comentario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }                
            }            
            return View(comentario);
        }

        [HttpGet("excluir/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var comentario = await _context.Comentarios
                .Include(c => c.Autor)
                .Include(c => c.Post)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (comentario == null) return NotFound();

            if (!comentario.PodeSermodificadoOuExcluidoPor(User)) return Unauthorized();

            return View(comentario);
        }

        
        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var comentario = await _context.Comentarios.Include(c=>c.Autor).FirstOrDefaultAsync(c=>c.Id == id);
            if (comentario == null) return NotFound();

            if (!comentario.PodeSermodificadoOuExcluidoPor(User)) return Unauthorized();

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Posts", new { id = comentario.PostId });

        }

        private bool ComentarioExists(int id)
        {
            return _context.Comentarios.Any(e => e.Id == id);
        }
    }
}
