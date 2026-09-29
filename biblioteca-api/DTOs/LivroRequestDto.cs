using System.ComponentModel.DataAnnotations;

namespace biblioteca_api.DTOs;

public class LivroRequestDto
{
    [Required(ErrorMessage = "O titulo e obrigatorio.")]
    [MaxLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O autor e obrigatorio.")]
    [MaxLength(150)]
    public string Autor { get; set; } = string.Empty;

    [Required(ErrorMessage = "O genero e obrigatorio.")]
    [MaxLength(100)]
    public string Genero { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string Descricao { get; set; } = string.Empty;

    [Range(1, 2100, ErrorMessage = "Ano de publicacao invalido.")]
    public int AnoPublicacao { get; set; }

    public bool Disponivel { get; set; } = true;
}
