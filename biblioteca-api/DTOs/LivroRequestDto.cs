namespace biblioteca_api.DTOs;

public class LivroRequestDto {
  public string Titulo { get; set; } = string.Empty;
  public string Autor { get; set; } = string.Empty;
  public string Genero { get; set; } = string.Empty;
  public string Descricao { get; set; } = string.Empty;
  public int AnoPublicacao { get; set; }
  public bool Disponivel { get; set; } = true;
}