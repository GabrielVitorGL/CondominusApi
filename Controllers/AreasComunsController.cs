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
    public class AreasComunsController : ControllerBase
    {
        private readonly DataContext _context;

        public AreasComunsController(DataContext context)
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

        [HttpPut]
        public async Task<IActionResult> Update(AreaComum areaComum)
        {
            try
            {
                AreaComum ac = await _context.AreasComuns
                    .FirstOrDefaultAsync(x => x.Id == areaComum.Id);

                if (ac == null)
                    return NotFound("Área comum não encontrada");

                ac.Nome = areaComum.Nome;

                _context.AreasComuns.Update(ac);
                await _context.SaveChangesAsync();

                return Ok(ac.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletarMuitos")]
        public async Task<IActionResult> DeleteAreasComuns([FromBody] int[] ids)
        {
            try
            {
                if (ids == null || ids.Length == 0)
                {
                    throw new Exception("Selecione áreas comuns para deletar.");
                }

                // Filtrar apenas IDs válidos e existentes no banco de dados
                var areascomunsParaDeletar = await _context.AreasComuns
                    .Where(u => ids.Contains(u.Id))
                    .ToListAsync();

                if (areascomunsParaDeletar.Count == 0)
                {
                    return NotFound("Nenhuma área comum encontrada para os IDs fornecidos.");
                }

                _context.AreasComuns.RemoveRange(areascomunsParaDeletar);

                int linhasAfetadas = await _context.SaveChangesAsync();

                // Após deletar as áreas comuns, recupere a lista atualizada
                var listaAtualizada = await _context.AreasComuns.ToListAsync();
                return Ok(listaAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}