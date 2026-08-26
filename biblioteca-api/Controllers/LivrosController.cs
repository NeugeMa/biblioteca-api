using biblioteca_api.Data;
using biblioteca_api.DTOs;
using biblioteca_api.Models;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public ActionResult<IEnumerable<Livro>> GetAll()
    {
        return Ok(_dbContext.Livros);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Livro> GetById(int id)
    {
        var livro = _dbContext.Livros.FirstOrDefault(l => l.Id == id);

        if (livro is null)
        {
            return NotFound();
        }

        return Ok(livro);
    }

    [HttpPost]
    public ActionResult<Livro> Create([FromBody] LivroRequestDto dto)
    {
        var livro = new Livro
        {
            Id = _dbContext.GetNextId(),
            Titulo = dto.Titulo,
            Autor = dto.Autor,
            Genero = dto.Genero,
            Descricao = dto.Descricao,
            AnoPublicacao = dto.AnoPublicacao,
            Disponivel = dto.Disponivel
        };

        _dbContext.Livros.Add(livro);

        return CreatedAtAction(nameof(GetById), new { id = livro.Id }, livro);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] LivroRequestDto dto)
    {
        var livro = _dbContext.Livros.FirstOrDefault(l => l.Id == id);

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

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var livro = _dbContext.Livros.FirstOrDefault(l => l.Id == id);

        if (livro is null)
        {
            return NotFound();
        }

        _dbContext.Livros.Remove(livro);

        return NoContent();
    }
}
