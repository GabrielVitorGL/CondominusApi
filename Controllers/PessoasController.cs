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
    public class PessoasController : ControllerBase
    {
        private readonly DataContext _context;

        public PessoasController(DataContext context)
        {
            _context = context;
        }

        //listagem geral de pessoas
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

        //listagem geral de pessoas com dependentes
        [HttpGet("GetAllDependentes")]
        public async Task<IActionResult> ListarDepAsync()
        {
            try
            {
                List<Pessoa> pessoas = await _context.Pessoas
                    .Include(p => p.Dependentes).ToListAsync();
                return Ok(pessoas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //listagem de pessoas com tipo morador
        [HttpGet("GetMoradores")]
        public async Task<IActionResult> ListarMoradoresAsync()
        {
            try
            {
                List<Pessoa> pessoas = await _context.Pessoas.ToListAsync();
                List<Pessoa> moradores = pessoas.Where(p => p.Perfil == "Morador").ToList();
                return Ok(moradores);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //listagem de pessoas com tipo sindico
        [HttpGet("GetSindicos")]
        public async Task<IActionResult> ListarSindicosAsync()
        {
            try
            {
                List<Pessoa> pessoas = await _context.Pessoas.ToListAsync();
                List<Pessoa> sindicos = pessoas.Where(p => p.Perfil == "Sindico").ToList();
                return Ok(sindicos);
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

        [HttpPut]
        public async Task<IActionResult> Update(Pessoa p)
        {
            try
            {
                Pessoa pessoa = await _context.Pessoas //Busca pessoa no banco através do Id
                    .FirstOrDefaultAsync(x => x.Id == p.Id);

                pessoa.Nome = p.Nome;
                pessoa.Telefone = p.Telefone;
                pessoa.Cpf = p.Cpf;
                //pessoa.IdApartamento = p.IdApartamento;

                var attach = _context.Attach(pessoa);
                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.Nome).IsModified = true;
                attach.Property(x => x.Perfil).IsModified = false;
                attach.Property(x => x.Telefone).IsModified = true;
                attach.Property(x => x.Cpf).IsModified = true;
                //attach.Property(x => x.IdApartamento).IsModified = true;

                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Pessoa pRemover = await _context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);

                _context.Pessoas.Remove(pRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletarMuitos")]
        public async Task<IActionResult> DeletarPessoas([FromBody] int[] ids)
        {
            try
            {
                if (ids == null || ids.Length == 0)
                {
                    throw new Exception("Selecione pessoas para deletar.");
                }

                // Filtrar apenas IDs válidos e existentes no banco de dados
                var pessoasParaDeletar = await _context.Pessoas
                    .Where(u => ids.Contains(u.Id))
                    .ToListAsync();

                if (pessoasParaDeletar.Count == 0)
                {
                    return NotFound("Nenhuma pessoa encontrada para os IDs fornecidos.");
                }

                _context.Pessoas.RemoveRange(pessoasParaDeletar);

                int linhasAfetadas = await _context.SaveChangesAsync();

                // Após deletar as pessoas, recupere a lista atualizada de usuários
                var listaAtualizada = await _context.Pessoas.ToListAsync();

                return Ok(listaAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}