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
    public class SindicoController : ControllerBase
    {
        private readonly DataContext _context; 

        public SindicoController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Sindico> sindicos = await _context.Sindicos.ToListAsync();                
                return Ok(sindicos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Sindico novoSindico)
        {
            try
            {
                await _context.Sindicos.AddAsync(novoSindico);
                await _context.SaveChangesAsync();

                return Ok(novoSindico.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}