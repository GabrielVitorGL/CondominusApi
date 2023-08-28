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
    public class AreaComumController : ControllerBase
    {
        private readonly DataContext _context; 

        public AreaComumController(DataContext context)
        {
            _context = context;
        } 

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<AreaComum> areasComuns = await _context.AreasComuns.ToListAsync();                
                return Ok(areasComuns);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AreaComum novaAreaComum)
        {
            try
            {
                await _context.AreasComuns.AddAsync(novaAreaComum);
                await _context.SaveChangesAsync();

                return Ok(novaAreaComum.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}