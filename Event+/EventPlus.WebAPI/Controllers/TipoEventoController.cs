using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoEventoController : ControllerBase
{
    private ITipoEventoRepository _eventoRepository;

    //injeção de dependência

    public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
    {
        _eventoRepository = tipoEventoRepository;
    }


    /// <summary>
    /// Endpoint da API faz a chamada para o método de lista os tipos de evento
    /// </summary>
    /// <returns>Status code 200 e a lista de tipo evento</returns>
    [HttpGet] //Get normal

    public IActionResult Listar()
    {
        try
        {
            return Ok(_eventoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para o método de buscar um tipo de evento específico
    /// </summary>
    /// <param name="id">Id do tipo de evento buscado</param>
    /// <returns>Status code 200 e o tipo de evento buscado</returns>
    [HttpGet("{id}")] //get por id

    public IActionResult BuscarPorId(Guid id) 
    {
        try
        {
            return Ok(_eventoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }



    /// <summary>
    /// EndPoint da API que faz a chamada para o método de cadastrar um método de evento
    /// </summary>
    /// <param name="tipoEvento">Tipo de evento a ser cadastrado</param>
    /// <returns>Code 201 e o tipo de evento a ser cadastrado </returns>
    [HttpPost]
    public IActionResult Cadastrar(TipoEventoDTO tipoEvento)
    {
        try
        {
            var novoTipoEvento = new TipoEvento 
            {
                Titulo = tipoEvento.Titulo!
            };

            _eventoRepository.Cadastrar(novoTipoEvento);
            return StatusCode(201, tipoEvento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }



    /// <summary>
    /// EndPoint da API que faz a chamada para o método de atualizar um tipo de evento
    /// </summary>
    /// <param name="id">Id do tipo evento a ser atualizado</param>
    /// <param name="tipoEvento">Tipo de evento com dados atualizados</param>
    /// <returns>Status Code 204 e o tipo de evento atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoEvento tipoEvento)
    {
        try
        {
            var tipoEventoAtualizado = new TipoEvento
            {
                Titulo = tipoEvento.Titulo!
            };

            _eventoRepository.Atualizar(id, tipoEventoAtualizado);

            return StatusCode(204, tipoEvento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// EndPoint da API que faz a chamada para o método para deletar um tipo de evento
    /// </summary>
    /// <param name="id">Id do tipo do evento a ser excluidp </param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _eventoRepository.Deletar(id);

            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    
    }
}
