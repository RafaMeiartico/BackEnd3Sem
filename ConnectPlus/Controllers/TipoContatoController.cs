using ConnectPlus.DTO;
using ConnectPlus.Interface;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoContatoController : ControllerBase
{
    private ITipoContatoRepository _contatoRepository;

    public TipoContatoController(ITipoContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }




    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_contatoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }




    [HttpGet("{id}")]

    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_contatoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }




    [HttpPost]
    public IActionResult Cadastrar(TipoContatoDTO tipoContato)
    {
        try
        {
            var novoContato = new TipoContato
            {
                Titulo = tipoContato.Titulo!
            };

            _contatoRepository.Cadastrar(novoContato);
            return StatusCode(201, tipoContato);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }




    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoContato tipoContato)
    {
        try
        {
            var contatoAtualizado = new TipoContato
            {
                Titulo = tipoContato.Titulo!
            };

            _contatoRepository.Atualizar(id, contatoAtualizado);

            return StatusCode(204, tipoContato);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }




    [HttpDelete("{id}")]

    public IActionResult Delete(Guid id)
    {
        try
        {
            _contatoRepository.Deletar(id);

            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
