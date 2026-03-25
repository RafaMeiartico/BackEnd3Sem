using Azure;
using Azure.AI.ContentSafety;
using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioEventoController : ControllerBase
{
    private readonly ContentSafetyClient _contentSafetyClient;

    private readonly IComentarioEventoRepository _comentarioEventoRepository;

    public ComentarioEventoController(ContentSafetyClient contentSafetyClient, IComentarioEventoRepository comentarioEventoRepository)
    {
        _contentSafetyClient = contentSafetyClient;
        _comentarioEventoRepository = comentarioEventoRepository;
    }


    [HttpPost]
    public async Task<IActionResult> Comentario(ComentarioEventoDTO comentarioEvento)
    {
        try
        {
            if (string.IsNullOrEmpty(comentarioEvento.Descricao))
            {
                return BadRequest("O texto a ser moderado não pode estar vazio");
            }

            //criar objeto de análise
            var request = new AnalyzeTextOptions(comentarioEvento.Descricao);

            //Chamar a API do Azure context safety
            Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);

            //Verificar se o texto tem alguma severidade maior que 0
            bool temConteudoImproprio = response.Value.CategoriesAnalysis.Any(c => c.Severity > 0);

            var novoComentario = new ComentarioEvento
            {
                IdEvento = comentarioEvento.IdEvento,
                IdUsuario = comentarioEvento.IdUsuario,
                Descricao = comentarioEvento.Descricao!,
                Exibe = !temConteudoImproprio,
                DataComentarioEvento = DateTime.Now
            };

            _comentarioEventoRepository.Cadastrar(novoComentario);

            return StatusCode(201, novoComentario);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }





    /// <summary>
    /// EndPoint da API faz a chamada para o método de lista os comentarios
    /// </summary>
    /// <returns>Status code 200 e os comentarios</returns>
    [HttpGet]
    public IActionResult Listar(Guid IdEvento)
    {
        try
        {
            return Ok(_comentarioEventoRepository.Listar(IdEvento));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }






    // <summary>
    /// Endpoint da API que faz a chamada para o método de buscar um comentario por um usuário específico
    /// </summary>
    /// <param name="id">Id do usuário que fez o comentário</param>
    /// <returns>Status code 200 e o usuário quecomentou </returns>
    [HttpGet("{idUsuario}/{idEvento}")]
    public IActionResult BuscarPorIdUsuario(Guid idUsuario, Guid idEvento)
    {
        try
        {
            return Ok(_comentarioEventoRepository.BuscarPorIdUsuario(idUsuario, idEvento));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Busca o comentário pelo evento específico
    /// </summary>
    /// <param name="IdEvento"> Id do evento</param>
    /// <returns>Retorna status 200 e os comentários do evento especificado</returns>
    [HttpGet("{IdEvento}")]
    public IActionResult ListarSomenteExibe(Guid IdEvento)
    {
        try
        {
            return Ok(_comentarioEventoRepository.ListarSomenteExibe(IdEvento));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }




    /// <summary>
    /// EndPoint da API que faz a chamada para o método para deletar um comentario
    /// </summary>
    /// <param name="id">Id do comentario a ser excluido </param>
    /// <returns></returns>
    [HttpDelete("{id}")]

    public IActionResult Delete(Guid id)
    {
        try
        {
            _comentarioEventoRepository.Deletar(id);

            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
