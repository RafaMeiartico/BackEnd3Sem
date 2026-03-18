using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "O Email obrigatório!!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória!!")]
    public string? Senha { get; set; }
}
