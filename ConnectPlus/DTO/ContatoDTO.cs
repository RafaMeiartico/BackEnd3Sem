using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class ContatoDTO
{
    [Required(ErrorMessage = "o titulo do contato é obrigatório!!")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "A forma de contato é obrigatória")]
    public string? FormaContato { get; set; }
    public IFormFile? Imagem { get; set; }
}
