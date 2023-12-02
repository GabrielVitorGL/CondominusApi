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
    [Authorize(Roles = "Admin, Sindico, Morador")]
    [ApiController]
    [Route("[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly DataContext _context;

        public ReservasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Reserva> reservas = await _context.Reservas
                .Include(r => r.Pessoa)
                .Include(r => r.AreaComum)
                .ToListAsync();
                return Ok(reservas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Reserva novaReserva)
        {
            try
            {
                await _context.Reservas.AddAsync(novaReserva);
                await _context.SaveChangesAsync();

                return Ok(novaReserva.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Reserva reservaAtualizada)
        {
            try
            {
                Reserva reserva = await _context.Reservas.FindAsync(reservaAtualizada.Id);

                if (reserva == null)
                    return NotFound("Reserva não encontrada");

                reserva.Data = reservaAtualizada.Data;

                _context.Reservas.Update(reserva);
                await _context.SaveChangesAsync();

                return Ok(reserva.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}