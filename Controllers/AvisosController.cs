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
    public class AvisosController : ControllerBase
    {
        private readonly DataContext _context;

        public AvisosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Aviso> avisos = await _context.Avisos.ToListAsync();
                return Ok(avisos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Aviso novoAviso)
        {
            try
            {
                await _context.Avisos.AddAsync(novoAviso);
                await _context.SaveChangesAsync();

                return Ok(novoAviso.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Aviso aviso)
        {
            try
            {
                Aviso av = await _context.Avisos
                    .FirstOrDefaultAsync(x => x.Id == aviso.Id);

                if (av != null)
                {
                    av.Assunto = aviso.Assunto;
                    av.Mensagem = aviso.Mensagem;

                    _context.Avisos.Update(av);
                    await _context.SaveChangesAsync();
                    return Ok(av.Id);
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
        public async Task<IActionResult> DeleteAvisos([FromBody] int[] ids)
        {
            try
            {
                if (ids == null || ids.Length == 0)
                {
                    throw new Exception("Selecione avisos para deletar.");
                }

                // Filtrar apenas IDs válidos e existentes no banco de dados
                var avisosParaDeletar = await _context.Avisos
                    .Where(u => ids.Contains(u.Id))
                    .ToListAsync();

                if (avisosParaDeletar.Count == 0)
                {
                    return NotFound("Nenhum aviso encontrado para os IDs fornecidos.");
                }

                _context.Avisos.RemoveRange(avisosParaDeletar);

                int linhasAfetadas = await _context.SaveChangesAsync();

                // Após deletar as áreas comuns, recupere a lista atualizada
                var listaAtualizada = await _context.Avisos.ToListAsync();
                return Ok(listaAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}