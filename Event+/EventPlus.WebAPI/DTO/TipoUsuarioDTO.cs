using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class TipoUsuarioDTO
{
    [Required(ErrorMessage = "o titulo de tipo usuário é obrigatório!!")]

    public string? Titulo { get; set; }
}
