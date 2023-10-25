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

        //listagem de pessoas com tipo morador
        [HttpGet("GetMoradores")]
        public async Task<IActionResult> ListarMoradoresAsync()
        {
            try
            {
                List<Pessoa> pessoas = await _context.Pessoas.ToListAsync();           
                List<Pessoa> moradores = pessoas.Where(p => p.Tipo == "Morador").ToList();                
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
                List<Pessoa> sindicos = pessoas.Where(p => p.Tipo == "Sindico").ToList();                
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
    }
}