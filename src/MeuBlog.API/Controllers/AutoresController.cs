using MeuBlog.Shared.Data;
using MeuBlog.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MeuBlog.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/meu-blog/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<Autor>>> Get()
        {
            if (_context.Autores == null) return NotFound();

            return await _context.Autores.ToListAsync();
        }
    }
}
