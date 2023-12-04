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
    public class DependentesController : ControllerBase
    {
        private readonly DataContext _context;

        public DependentesController(DataContext context)
        {
            _context = context;
        }

        //listagem geral de pessoas
        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Dependente> dependentes = await _context.Dependentes.ToListAsync();
                return Ok(dependentes);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Dependente novoDependente)
        {
            try
            {
                // Pessoa temp = await _context.Pessoas.FirstOrDefaultAsync(p => p.Id.Equals(novoDependente.IdPessoa));
                // temp.Dependentes.Add(novoDependente);
                // _context.Pessoas.Update(temp);

                await _context.Dependentes.AddAsync(novoDependente);
                await _context.SaveChangesAsync();

                return Ok(novoDependente.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Dependente dependente)
        {
            try
            {
                Dependente dp = await _context.Dependentes
                    .FirstOrDefaultAsync(x => x.Id == dependente.Id);

                if (dp != null)
                {
                    dp.Nome = dependente.Nome;
                    dp.Telefone = dependente.Telefone;

                    _context.Dependentes.Update(dp);
                    await _context.SaveChangesAsync();
                    return Ok(dp.Id);
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
        public async Task<IActionResult> DeleteDependentes([FromBody] int[] ids)
        {
            try
            {
                if (ids == null || ids.Length == 0)
                {
                    throw new Exception("Selecione dependentes para deletar.");
                }

                // Filtrar apenas IDs válidos e existentes no banco de dados
                var dependentesParaDeletar = await _context.Dependentes
                    .Where(u => ids.Contains(u.Id))
                    .ToListAsync();

                if (dependentesParaDeletar.Count == 0)
                {
                    return NotFound("Nenhum dependente encontrado para os IDs fornecidos.");
                }

                _context.Dependentes.RemoveRange(dependentesParaDeletar);

                int linhasAfetadas = await _context.SaveChangesAsync();

                // Após deletar as áreas comuns, recupere a lista atualizada
                var listaAtualizada = await _context.Dependentes.ToListAsync();
                return Ok(listaAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}