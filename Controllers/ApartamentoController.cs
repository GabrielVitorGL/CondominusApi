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
    public class ApartamentoController : ControllerBase
    {
        private readonly DataContext _context; 

        public ApartamentoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Apartamento> apartamentos = await _context.Apartamentos.ToListAsync();                
                return Ok(apartamentos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Apartamento novoApartamento)
        {
            try
            {
                await _context.Apartamentos.AddAsync(novoApartamento);
                await _context.SaveChangesAsync();

                return Ok(novoApartamento.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}