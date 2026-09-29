using biblioteca_api.Data;
using biblioteca_api.DTOs;
using biblioteca_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_api.Controllers;

[ApiController]
[Route("api/v1/livros")]
public class LivrosController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public LivrosController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET /api/v1/livros
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Livro>>> GetAll()
    {
        var livros = await _dbContext.Livros.AsNoTracking().ToListAsync();
        return Ok(livros);
    }

    // GET /api/v1/livros/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Livro>> GetById(int id)
    {
        var livro = await _dbContext.Livros.FindAsync(id);

        if (livro is null)
        {
            return NotFound();
        }

        return Ok(livro);
    }

    // POST /api/v1/livros
    [HttpPost]
    public async Task<ActionResult<Livro>> Create([FromBody] LivroRequestDto dto)
    {
        var livro = new Livro
        {
            Titulo = dto.Titulo,
            Autor = dto.Autor,
            Genero = dto.Genero,
            Descricao = dto.Descricao,
            AnoPublicacao = dto.AnoPublicacao,
            Disponivel = dto.Disponivel
        };

        _dbContext.Livros.Add(livro);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = livro.Id }, livro);
    }

    // PUT /api/v1/livros/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] LivroRequestDto dto)
    {
        var livro = await _dbContext.Livros.FindAsync(id);

        if (livro is null)
        {
            return NotFound();
        }

        livro.Titulo = dto.Titulo;
        livro.Autor = dto.Autor;
        livro.Genero = dto.Genero;
        livro.Descricao = dto.Descricao;
        livro.AnoPublicacao = dto.AnoPublicacao;
        livro.Disponivel = dto.Disponivel;

        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    // DELETE /api/v1/livros/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var livro = await _dbContext.Livros.FindAsync(id);

        if (livro is null)
        {
            return NotFound();
        }

        _dbContext.Livros.Remove(livro);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}
