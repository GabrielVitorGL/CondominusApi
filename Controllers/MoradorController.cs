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
    public class MoradorController : ControllerBase
    {
        private readonly DataContext _context; 

        public MoradorController(DataContext context)
        {
            _context = context;
        } 

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Morador> moradores = await _context.Moradores.ToListAsync();                
                return Ok(moradores);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Morador novoMorador)
        {
            try
            {
                await _context.Moradores.AddAsync(novoMorador);
                await _context.SaveChangesAsync();

                return Ok(novoMorador.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}