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
    public class ApartamentosController : ControllerBase
    {
        private readonly DataContext _context;

        public ApartamentosController(DataContext context)
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

        [HttpPut]
        public async Task<IActionResult> Update(Apartamento apartamento)
        {
            try
            {
                Apartamento ap = await _context.Apartamentos
                    .FirstOrDefaultAsync(x => x.Id == apartamento.Id);

                if (ap != null)
                {
                    ap.Numero = apartamento.Numero;
                    ap.Telefone = apartamento.Telefone;

                    _context.Apartamentos.Update(ap);
                    await _context.SaveChangesAsync();
                    return Ok(ap.Id);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletarMuitos")]
        public async Task<IActionResult> DeleteApartamentos([FromBody] int[] ids)
        {
            try
            {
                if (ids == null || ids.Length == 0)
                {
                    throw new Exception("Selecione apartamentos para deletar.");
                }

                // Filtrar apenas IDs válidos e existentes no banco de dados
                var apartamentosParaDeletar = await _context.Apartamentos
                    .Where(u => ids.Contains(u.Id))
                    .ToListAsync();

                if (apartamentosParaDeletar.Count == 0)
                {
                    return NotFound("Nenhum apartamento encontrado para os IDs fornecidos.");
                }

                _context.Apartamentos.RemoveRange(apartamentosParaDeletar);

                int linhasAfetadas = await _context.SaveChangesAsync();

                // Após deletar as áreas comuns, recupere a lista atualizada
                var listaAtualizada = await _context.Apartamentos.ToListAsync();
                return Ok(listaAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}