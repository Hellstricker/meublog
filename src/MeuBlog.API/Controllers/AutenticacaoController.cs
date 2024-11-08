using MeuBlog.Api.Models;
using MeuBlog.Shared.Data;
using MeuBlog.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeuBlog.Api.Controllers
{
    [ApiController]
    [Route("api/v1/meublog/conta")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly ApplicationDbContext _context;
        public AutenticacaoController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _context = context;
        }

        [HttpPost("cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Cadastrar(RegisterModel model)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var user = new IdentityUser()
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password!);


            if (!result.Succeeded) return Problem("Falha ao cadastrar usuario", statusCode: StatusCodes.Status400BadRequest);

            var autor = new Autor()
            {
                Nome = model.Nome,
                Id = await _userManager.GetUserIdAsync(user)
            };
            _context.Add(autor);
            await _context.SaveChangesAsync();

            await _signInManager.SignInAsync(user, false);
            return Ok(await GetJwt(model.Email!));
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> LoginAsync(LoginModel model)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email!);

            if (user == null) return Problem("Usuário ou senha incorretos, tente novamente", statusCode: StatusCodes.Status400BadRequest);

            var result = await _signInManager.PasswordSignInAsync(_userManager.FindByEmailAsync(model.Email!).Result!, model.Password!, false, true);

            if (!result.Succeeded) return Problem("Usuário ou senha incorretos, tente novamente", statusCode:StatusCodes.Status400BadRequest);

            return Ok(await GetJwt(model.Email!));
        }


        private async Task<string> GetJwt(string email)
        {
            var  user  = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user!);

            var claims = new List<Claim>();
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, await _userManager.GetUserIdAsync(user!)));

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtSettings.Segredo!);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _jwtSettings.Emissor,
                Audience = _jwtSettings.Audiencia,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.HorasParaExpirar),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }
    }
}
