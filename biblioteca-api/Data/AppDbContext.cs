using biblioteca_api.Models;

namespace biblioteca_api.Data;

public class AppDbContext {
  public List<Livro> Livros { get; set; } = new();
  private int _nextId = 1;

  public int GetNextId() => _nextId++;
}