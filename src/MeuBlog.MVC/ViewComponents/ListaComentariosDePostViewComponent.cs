using MeuBlog.Shared.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuBlog.Mvc.ViewComponents
{
    public class ListaComentariosDePostViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ListaComentariosDePostViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int postId)
        {
            var comentarios = await _context.Comentarios.Include(c=>c.Autor).Where(c=>c.PostId == postId).ToListAsync();
            return View(comentarios.OrderByDescending(c=>c.DataCriacao));
        }
    }
}
