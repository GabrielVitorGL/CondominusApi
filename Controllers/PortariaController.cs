using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondominusApi.Data;
using CondominusApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CondominusApi.Controllers
{
    [Authorize(Roles = "Admin, Sindico")]
    [ApiController]
    [Route("[controller]")]
    public class PortariasController : ControllerBase
    {
        private readonly DataContext _context; 

        public PortariasController(DataContext context)
        {
            _context = context;
        } 

        //listagem geral de pessoas
        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Portaria> portarias = await _context.Portarias.ToListAsync();
                return Ok(portarias);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Portaria novaPortaria)
        {
            try
            {
                await _context.Portarias.AddAsync(novaPortaria);
                await _context.SaveChangesAsync();

                return Ok(novaPortaria.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}