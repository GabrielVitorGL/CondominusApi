using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using CondominusApi.Data;
using CondominusApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominusApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CondominioController : ControllerBase
    {
        private readonly DataContext _context; 

        public CondominioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Condominio> condominios = await _context.Condominios.ToListAsync();                
                return Ok(condominios);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Condominio novoCondominio)
        {
            try
            {
                await _context.Condominios.AddAsync(novoCondominio);
                await _context.SaveChangesAsync();

                return Ok(novoCondominio.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}