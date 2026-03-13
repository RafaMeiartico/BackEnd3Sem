using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "o Nome da Instituição é obrigatória!!")]
    public string? NomeFantasia { get; set; }

    [Required(ErrorMessage = "o endereço da Instituição é obrigatório!!")]
    public string? Endereco { get; set; }

    [Required(ErrorMessage = "o Cnpj da Instituição é obrigatório!!")]
    public string? Cnpj { get; set; }

}
