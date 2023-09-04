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
    public class PessoaController : ControllerBase
    {
        private readonly DataContext _context; 

        public PessoaController(DataContext context)
        {
            _context = context;
        } 

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Pessoa> pessoas = await _context.Pessoas.ToListAsync();                
                return Ok(pessoas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Pessoa novoPessoa)
        {
            try
            {
                await _context.Pessoas.AddAsync(novoPessoa);
                await _context.SaveChangesAsync();

                return Ok(novoPessoa.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}