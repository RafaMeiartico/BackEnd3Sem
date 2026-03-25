using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : ControllerBase
{
    private IPresencaRepository _presencaRepository;

    public PresencaController(IPresencaRepository presencaRepository)
    {
        _presencaRepository = presencaRepository;
    }




    /// <summary>
    /// EndPoint da API que retorna uma lista de presença de um usuário específico
    /// </summary>
    /// <param name="idUsuario">id do usuário para filtragem</param>
    /// <returns>Status code 200 e uma lista de presenças</returns>
    [HttpGet("ListarMinhas/{idUsuario}")]

    public IActionResult BuscarMinhas(Guid idUsuario)
    {
        try
        {
            return Ok(_presencaRepository.ListarMinhas(idUsuario));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }



    /// <summary>
    /// Endpoint da API faz a chamada para o método de lista as presenças
    /// </summary>
    /// <returns>Status code 200 e a lista de tipo evento</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_presencaRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }



    /// <summary>
    /// Endpoint da API que faz a chamada para o método de buscar uma presença específica
    /// </summary>
    /// <param name="id">Id da presença a ser buscado</param>
    /// <returns>Status code 200 e o a presença buscada</returns>
    [HttpGet("{id}")]

    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_presencaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }



    /// <summary>
    /// EndPoint da API que faz a chamada para o método de inscrever uma presença
    /// </summary>
    /// <param name="presenca">Presença a ser inscrita</param>
    /// <returns>Code 201 e a presença a ser inscrita</returns>
    [HttpPost]
    public IActionResult Inscrever(PresencaDTO presenca)
    {
        try
        {
            var novaPresenca = new Presenca
            {
                Situacao = presenca.Situacao!,
                IdEvento = presenca.IdEvento!,
                IdUsuario = presenca.IdUsuario!
            };

            _presencaRepository.Inscrever(novaPresenca);
            return StatusCode(201, novaPresenca);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }



    /// <summary>
    /// EndPoint da API que faz a chamada para o método de atualizar as presenças
    /// </summary>
    /// <param name="id">Id da presença a ser atualizada</param>
    /// <param name="tipoEvento">Presença com dados atualizados</param>
    /// <returns>Status Code 204 e a presença atualizada</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id)
    {
        try
        {
            _presencaRepository.Atualizar(id);

            return StatusCode(204);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// EndPoint da API que faz a chamada para o método para deletar uma presença
    /// </summary>
    /// <param name="id">Id da presença a ser excluida </param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _presencaRepository.Deletar(id);

            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }

    }

}
