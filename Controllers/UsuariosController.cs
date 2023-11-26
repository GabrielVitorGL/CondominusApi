using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CondominusApi.Models;
using CondominusApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CondominusApi.Utils;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace CondominusApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public UsuariosController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string CriarToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Role, usuario.Perfil)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration
            .GetSection("ConfiguracaoToken:Chave").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost("GetUser")]
        public async Task<IActionResult> Get(Usuario u)
        {
            try
            {
                Usuario uRetornado = await _context.Usuarios
                    .FirstOrDefaultAsync(x => x.Nome == u.Nome && u.Email == u.Email);

                if (uRetornado == null)
                    throw new Exception("Usuário não encontrado");

                return Ok(uRetornado);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Usuario> lista = await _context.Usuarios.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<bool> UsuarioExistente(string username)
        {
            if (await _context.Usuarios.AnyAsync(x => x.Nome.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }
        private async Task<bool> ApartamentoExistente(int ap)
        {
            if (await _context.Usuarios.AnyAsync(x => x.IdApartamento == ap))
            {
                return true;
            }
            return false;
        }

        [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.Email) || await ApartamentoExistente(user.IdApartamento))
                    throw new System.Exception("E-mail ja cadastrado.");

                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.Usuarios.AddAsync(user);

                Pessoa pessoa = new Pessoa
                {
                    Nome = user.Nome,
                    Cpf = user.Cpf,
                    Telefone = user.Telefone,
                    Perfil = user.Perfil
                };
                await _context.Pessoas.AddAsync(pessoa);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /* eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJVc3VhcmlvQWRtaW4iLCJuYmYiOjE2OTMyMjQ0NjAsImV4cCI6MTY5MzMxMDg2MCwiaWF0IjoxNjkzMjI0NDYwfQ.tfzKDR22gQ7K60A5Sj0hf5_v9spygsgfGQ4mPeLYxTqYRpKRPeijMtGjGMrI9LhOgAoHdLlFDbABWjdzB2uq0Q*/
        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuarios
                   .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(credenciais.Email.ToLower()));

                if (usuario == null)
                    throw new System.Exception("Usuário não encontrado.");
                else if (!Criptografia.VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                    throw new System.Exception("Senha incorreta.");
                else
                {
                    usuario.DataAcesso = System.DateTime.Now;
                    _context.Usuarios.Update(usuario);
                    await _context.SaveChangesAsync(); //Confirma a alteração no banco

                    usuario.PasswordHash = null;
                    usuario.PasswordSalt = null;
                    usuario.Token = CriarToken(usuario);

                    return Ok(usuario);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetUsuario(int usuarioId)
        {
            try
            {
                //List exigirá o using System.Collections.Generic
                Usuario usuario = await _context.Usuarios //Busca o usuário no banco através do Id
                    .FirstOrDefaultAsync(x => x.Id == usuarioId);
                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByLogin/{login}")]
        public async Task<IActionResult> GetUsuario(string login)
        {
            try
            {
                //List exigirá o using System.Collections.Generic
                Usuario usuario = await _context.Usuarios //Busca o usuário no banco através do login
                .FirstOrDefaultAsync(x => x.Nome.ToLower() == login.ToLower());
                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Método para alteração da geolocalização
        // [HttpPut("AtualizarLocalizacao")]
        // public async Task<IActionResult> AtualizarLocalizacao(Usuario u)
        // {
        //     try
        //     {
        //         Usuario usuario = await _context.Usuarios //Busca o usuário no banco através do Id
        //         .FirstOrDefaultAsync(x => x.Id == u.Id);
        //         usuario.Latitude = u.Latitude;
        //         usuario.Longitude = u.Longitude;
        //         var attach = _context.Attach(usuario);
        //         attach.Property(x => x.Id).IsModified = false;
        //         attach.Property(x => x.Latitude).IsModified = true;
        //         attach.Property(x => x.Longitude).IsModified = true;
        //         int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
        //         return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

        //Método para alteração do e-mail
        [HttpPut("AtualizarEmail")]
        public async Task<IActionResult> AtualizarEmail(Usuario u)
        {
            try
            {
                Usuario usuario = await _context.Usuarios //Busca o usuário no banco através do Id
                .FirstOrDefaultAsync(x => x.Id == u.Id);
                usuario.Email = u.Email;
                var attach = _context.Attach(usuario);
                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.Email).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // //Método para alteração da foto
        // [HttpPut("AtualizarFoto")]
        // public async Task<IActionResult> AtualizarFoto(Usuario u)
        // {
        //     try
        //     {
        //         Usuario usuario = await _context.Usuarios
        //         .FirstOrDefaultAsync(x => x.Id == u.Id);
        //         usuario.Foto = u.Foto;
        //         var attach = _context.Attach(usuario);
        //         attach.Property(x => x.Id).IsModified = false;
        //         attach.Property(x => x.Foto).IsModified = true;
        //         int linhasAfetadas = await _context.SaveChangesAsync();
        //         return Ok(linhasAfetadas);
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

        













    }
}