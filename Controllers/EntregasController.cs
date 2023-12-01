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
    public class EntregasController : ControllerBase
    {
        private readonly DataContext _context;

        public EntregasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Entrega> entregas = await _context.Entregas.ToListAsync();
                List<EntregaComApartamento> entregasComApartamento = new List<EntregaComApartamento>();

                foreach (var entrega in entregas)
                {
                    Apartamento ap = await _context.Apartamentos.FirstOrDefaultAsync(x => x.Id == entrega.IdApartamento);

                    if (ap != null)
                    {
                        // Cria um novo objeto de entrega com o número do apartamento
                        EntregaComApartamento entregaComAp = new EntregaComApartamento
                        {
                            Id = entrega.Id,
                            Destinatario = entrega.Destinatario,
                            DataEntrega = entrega.DataEntrega,
                            DataRetirada = entrega.DataRetirada,
                            IdApartamento = entrega.IdApartamento,

                            NumeroApartamento = ap.Numero
                        };

                        entregasComApartamento.Add(entregaComAp);
                    }
                }

                return Ok(entregasComApartamento);
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
                Apartamento ap = await _context.Apartamentos
                    .FirstOrDefaultAsync(x => x.Id == novaEntrega.IdApartamento);

                novaEntrega.Apartamento = ap;
                await _context.Entregas.AddAsync(novaEntrega);
                await _context.SaveChangesAsync();

                return Ok(novaEntrega.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Entrega entregaAtualizada)
        {
            try
            {
                Entrega entrega = await _context.Entregas
                    .FirstOrDefaultAsync(x => x.Id == entregaAtualizada.Id);

                if (entrega == null)
                {
                    return NotFound();
                }


                if (!string.IsNullOrEmpty(entregaAtualizada.Destinatario))
                {
                    entrega.Destinatario = entregaAtualizada.Destinatario;
                }
                if (entregaAtualizada.DataRetirada != null)
                {
                    entrega.DataRetirada = entregaAtualizada.DataRetirada;
                }
                if (entregaAtualizada.IdApartamento != 0)
                {
                    entrega.IdApartamento = entregaAtualizada.IdApartamento;
                }


                await _context.SaveChangesAsync();

                return Ok(entrega);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletarMuitos")]
        public async Task<IActionResult> DeletarEntregas([FromBody] int[] ids)
        {
            try
            {
                if (ids == null || ids.Length == 0)
                {
                    throw new Exception("Selecione entregas para deletar.");
                }

                // Filtrar apenas IDs válidos e existentes no banco de dados
                var entregasParaDeletar = await _context.Entregas
                    .Where(u => ids.Contains(u.Id))
                    .ToListAsync();

                if (entregasParaDeletar.Count == 0)
                {
                    return NotFound("Nenhuma entrega encontrada para os IDs fornecidos.");
                }

                _context.Entregas.RemoveRange(entregasParaDeletar);

                int linhasAfetadas = await _context.SaveChangesAsync();

                // Após deletar as entregas, recupere a lista atualizada de usuários
                var listaAtualizada = await _context.Entregas.ToListAsync();

                return Ok(listaAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}