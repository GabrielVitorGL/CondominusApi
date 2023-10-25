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
    [Authorize(Roles = "Admin, Sindico")]
    [ApiController]
    [Route("[controller]")]
    public class ApartPessoasController : ControllerBase
    {
        private readonly DataContext _context; 

        public ApartPessoasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<ApartPessoa> apartPessoas = await _context.ApartPessoas.ToListAsync();                
                return Ok(apartPessoas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ApartPessoa novoApartPessoa)
        {
            try
            {
                await _context.ApartPessoas.AddAsync(novoApartPessoa);
                await _context.SaveChangesAsync();

                return Ok(novoApartPessoa.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}