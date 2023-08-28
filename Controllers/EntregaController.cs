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
    public class EntregaController : ControllerBase
    {
        private readonly DataContext _context; 

        public EntregaController(DataContext context)
        {
            _context = context;
        }  

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Entrega> entregas = await _context.Entregas.ToListAsync();                
                return Ok(entregas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Entrega novaEntrega)
        {
            try
            {
                await _context.Entregas.AddAsync(novaEntrega);
                await _context.SaveChangesAsync();

                return Ok(novaEntrega.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}