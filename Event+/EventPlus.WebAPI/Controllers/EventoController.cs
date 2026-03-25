using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{ 
    private IEventoRepository _eventoRepository;

    public EventoController(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }



    /// <summary>
    /// EndPoint da API faz a chamada para o método de listar eventos filtrado por usuário
    /// </summary>
    /// <param name="idUsuario">Id do usuário para filtragem</param>
    /// <returns>Lista de eventos filtragem por usuario</returns>
    [HttpGet("Usuario/{idUsuario}")]

    public IActionResult ListarPorId(Guid idUsuario)
    {
        try
        {
            return Ok(_eventoRepository.ListarPorId(idUsuario));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }



    /// <summary>
    /// EndPoint da API faz a chamada para o método de lista os tipos de evento
    /// </summary>
    /// <returns>Status code 200 e a lista de evento</returns>
    [HttpGet]
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




    // <summary>
    /// Endpoint da API que faz a chamada para o método de buscar um evento específico
    /// </summary>
    /// <param name="id">Id do evento buscado</param>
    /// <returns>Status code 200 e o evento buscado</returns>
    [HttpGet("{id}")]

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
    /// EndPoint da API que faz a chamafa para o método de listar os próximos eventos
    /// </summary>
    /// <returns>code 200 e uma lista de proximos eventos</returns>
    [HttpGet("ListarProximos")]

    public IActionResult BuscarProximos()
    {
        try
        {
            return Ok(_eventoRepository.ListarProximos());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }



    /// <summary>
    /// EndPoint da API que faz a chamada para o método de cadastrar um evento
    /// </summary>
    /// <param name="Evento">Evento a ser cadastrado</param>
    /// <returns>Code 201 e o evento a ser cadastrado </returns>
    [HttpPost]
    public IActionResult Cadastrar(EventoDTO Evento)
    {
        try
        {
            var novoEvento = new Evento
            {
                Descricao = Evento.Descricao!,
                Nome = Evento.Nome!,
                DataEvento = Evento.DataEvento!,
                IdInstituicao = Evento.IdInstituicao!,
                IdTipoEvento = Evento.IdTipoEvento
            };

            _eventoRepository.Cadastrar(novoEvento);
            return StatusCode(201, Evento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }




    /// <summary>
    /// EndPoint da API que faz a chamada para o método de atualizar um evento
    /// </summary>
    /// <param name="id">Id do evento a ser atualizado</param>
    /// <param name="evento"> evento com dados atualizados</param>
    /// <returns>Status Code 204 e o evento atualizado</returns>
    [HttpPut("{id}")]

    public IActionResult Atualizar(Guid id, Evento evento)
    {
          try
            {
                var novoEventoAtualizado = new Evento
                {
                    Descricao = evento.Descricao!,
                    Nome = evento.Nome!,
                    DataEvento = evento.DataEvento!,
                    IdEvento = evento.IdEvento!,
                    IdInstituicao = evento.IdInstituicao!,
                    IdTipoEvento = evento.IdTipoEvento
                };

                _eventoRepository.Atualizar(id, novoEventoAtualizado);

           
            return StatusCode(204, evento);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
    }



    /// <summary>
    /// EndPoint da API que faz a chamada para o método para deletar um evento
    /// </summary>
    /// <param name="id">Id do evento a ser excluido </param>
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
