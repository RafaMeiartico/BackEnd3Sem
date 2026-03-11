using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "o titulo de Instituição é obrigatório!!")]

    public string? Titulo { get; set; }
    
}
