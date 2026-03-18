using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class EventoDTO
{
    [Required(ErrorMessage = "A descrição do evento é obrigatória!")]
    public string? Descricao { get; set; }


    [Required(ErrorMessage = "O nome do evento é obrigatório!")]
    public string? Nome { get; set; }


    [Required(ErrorMessage = "O nome do evento é obrigatório!")]
    public DateTime DataEvento { get; set; }


    [Required(ErrorMessage = "O nome do evento é obrigatório!")]
    public Guid IdEvento { get; set; }


    [Required(ErrorMessage = "O nome do evento é obrigatório!")]
    public Guid IdTipoEvento { get; set; }


    [Required(ErrorMessage = "O nome do evento é obrigatório!")]
    public Guid IdInstituicao { get; set; }

}
