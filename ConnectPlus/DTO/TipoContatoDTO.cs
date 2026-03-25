using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class TipoContatoDTO
{
    [Required(ErrorMessage = "o titulo do contato é obrigatório!!")]
    public string? Titulo { get; set; }
}
