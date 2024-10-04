using MeuBlog.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MeuBlog.Mvc.ViewComponents
{
    public class CriarComentarioEmPostViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(int postId)
        {
            ViewBag.ReturnUrl = HttpContext.Request.Path;
            return View(new Comentario() { PostId = postId });
        }
    }
}
