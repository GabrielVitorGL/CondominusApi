using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using CondominusApi.Data;
using CondominusApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CondominusApi.Controllers
{
    public class AvisosController
    {
        [Authorize(Roles = "Admin, Sindico, Morador")]
        [ApiController]
        [Route("[controller]")]
        public class AvisosController : ControllerBase
        {
            private readonly DataContext _context; 

            public AvisosController(DataContext context)
            {
                _context = context;
            }

            [HttpGet("GetAll")]
            public async Task<IActionResult> ListarAsync()
            {
                try
                {
                    List<Aviso> avisos = await _context.Condominios.ToListAsync();                
                    return Ok(avisos);
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPost]
            public async Task<IActionResult> Add(Aviso novoAviso)
            {
                try
                {
                    await _context.Avisos.AddAsync(novoAviso);
                    await _context.SaveChangesAsync();

                    return Ok(novoAviso.Id);
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}