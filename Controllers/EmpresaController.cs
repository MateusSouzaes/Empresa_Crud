using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD_Empresa.DataContexts; 
using CRUD_Empresa.Models;       
using CRUD_Empresa.Models.Dtos;  

namespace CRUD_Empresa.Controllers
{
    [Route("/crud_empresas")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly AppDbContext _context; 

        public EmpresaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet ("listagem")]
        public async Task<IActionResult> ListarEmpresas([FromQuery] string? search)
        {
            var query = _context.Empresas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchTerm = search.ToLower().Trim();

                query = query.Where(e =>
                    e.NomeRazao.ToLower().Contains(searchTerm) ||
                    e.Cnpj.Contains(searchTerm) ||
                    e.NomeFantasia.ToLower().Contains(searchTerm)
                );
            }

            var empresas = await query
                .Select(e => new 
                {
                    Id = e.Id,
                    NomeRazao = e.NomeRazao, 
                    NomeFantasia = e.NomeFantasia,
                    Cnpj = e.Cnpj,
                    Telefone = e.Telefone,
                    Email = e.Email,
                })
                .ToListAsync();

            return Ok(empresas);
        }
        [HttpGet("listagem_completa")]
        public async Task<IActionResult> ListarEmpresasAll([FromQuery] string? search)
        {
            var query = _context.Empresas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchTerm = search.ToLower().Trim();
                query = query.Where(e =>
                    e.NomeRazao.ToLower().Contains(searchTerm) ||
                    e.Cnpj.Contains(searchTerm) ||
                    e.NomeFantasia.ToLower().Contains(searchTerm)
                );
            }

            var empresas = await query
                .Select(e => new EmpresaDto
                {
                    NomeRazao = e.NomeRazao,
                    NomeFantasia = e.NomeFantasia,
                    Cnpj = e.Cnpj,
                    Telefone = e.Telefone,
                    Email = e.Email,
                    Cidade = e.Cidade,
                    Uf = e.Estado.Uf,
                    Cep = e.Cep, 

                })
                .ToListAsync();

            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarEmpresaPorId(int id)
        {
            var empresa = await _context.Empresas
                .Include(e => e.Estado)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (empresa is null)
            {
                return NotFound("Empresa não encontrada.");
            }

            var empresaDto = new EmpresaDto
            {
                NomeRazao = empresa.NomeRazao,
                NomeFantasia = empresa.NomeFantasia,
                Cnpj = empresa.Cnpj,
                InscEstadual = empresa.InscEstadual,
                Telefone = empresa.Telefone,
                Email = empresa.Email,
                Cidade = empresa.Cidade,
                Uf = empresa.Estado.Uf,
                Cep = empresa.Cep,
            };

            return Ok(empresaDto);
        }

        [HttpPost]
        public async Task<IActionResult> CriarEmpresa([FromBody] EmpresaDto novaEmpresa)
        {
            var cnpjJaExiste = await _context.Empresas.AnyAsync(e => e.Cnpj == novaEmpresa.Cnpj);
            if (cnpjJaExiste)
            {
                return BadRequest("O CNPJ informado já está cadastrado.");
            }

            var estado = await _context.Estados.FirstOrDefaultAsync(est => est.Uf == novaEmpresa.Uf);
            if (estado is null)
            {
                return BadRequest("A UF informada não é válida.");
            }

            var empresa = new Empresa()
            {
                NomeRazao = novaEmpresa.NomeRazao,
                NomeFantasia = novaEmpresa.NomeFantasia,
                Cnpj = novaEmpresa.Cnpj,
                InscEstadual = novaEmpresa.InscEstadual,
                Telefone = novaEmpresa.Telefone,
                Email = novaEmpresa.Email,
                Cidade = novaEmpresa.Cidade,
                Cep = novaEmpresa.Cep,
                EstadoId = estado.Id
            };

            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();



            return Created("",empresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEmpresa(int id, [FromBody] EmpresaDto empresaAtualizadaDto)
        {
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa is null)
            {
                return NotFound("Empresa não encontrada.");
            }

            var cnpjJaExiste = await _context.Empresas.AnyAsync(e => e.Cnpj == empresaAtualizadaDto.Cnpj && e.Id != id);
            if (cnpjJaExiste)
            {
                return BadRequest("O CNPJ informado já pertence a outra empresa.");
            }

            var estado = await _context.Estados.FirstOrDefaultAsync(est => est.Uf == empresaAtualizadaDto.Uf);
            if (estado is null)
            {
                return BadRequest("A UF informada não é válida.");
            }

            empresa.NomeRazao = empresaAtualizadaDto.NomeRazao; 
            empresa.Cnpj = empresaAtualizadaDto.Cnpj;
            empresa.InscEstadual = empresaAtualizadaDto.InscEstadual;
            empresa.Telefone = empresaAtualizadaDto.Telefone;
            empresa.Email = empresaAtualizadaDto.Email;
            empresa.Cidade = empresaAtualizadaDto.Cidade;
            empresa.Cep = empresaAtualizadaDto.Cep;
            empresa.EstadoId = estado.Id;

            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();


            return Ok(empresaAtualizadaDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa is null)
            {
                return NotFound("Empresa não encontrada.");
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}