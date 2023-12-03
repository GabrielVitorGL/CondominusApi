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
                AreaComum ac = await _context.AreasComuns
                    .FirstOrDefaultAsync(x => x.Id == novaReserva.IdAreaComum);

                Pessoa p = await _context.Pessoas
                    .FirstOrDefaultAsync(x => x.Id == novaReserva.IdPessoa);

                novaReserva.AreaComum = ac;
                novaReserva.Pessoa = p;
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

                // mudar para poder alterar as duas datas: inicial e/ou final
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

        [HttpDelete("DeletarMuitos")]
        public async Task<IActionResult> DeleteReservas([FromBody] int[] ids)
        {
            try
            {
                if (ids == null || ids.Length == 0)
                {
                    throw new Exception("Selecione reservas para deletar.");
                }

                // Filtrar apenas IDs válidos e existentes no banco de dados
                var reservasParaDeletar = await _context.Reservas
                    .Where(u => ids.Contains(u.Id))
                    .ToListAsync();

                if (reservasParaDeletar.Count == 0)
                {
                    return NotFound("Nenhuma reserva encontrada para os IDs fornecidos.");
                }

                _context.Reservas.RemoveRange(reservasParaDeletar);

                int linhasAfetadas = await _context.SaveChangesAsync();

                // Após deletar as reservas, recupere a lista atualizada de reservas
                var listaAtualizada = await _context.Reservas.ToListAsync();
                return Ok(listaAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}