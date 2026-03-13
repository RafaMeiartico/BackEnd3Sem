using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private ITipoUsuarioRepository _usuarioRepositoy;

    public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
    {
        _usuarioRepositoy = tipoUsuarioRepository;
    }




    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_usuarioRepositoy.Listar());
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
            return Ok(_usuarioRepositoy.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }




    [HttpPost]
    public IActionResult Cadastrar(TipoUsuarioDTO tipoUsuario)
    {
        try
        {
            var novoUsuario = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };

            _usuarioRepositoy.Cadastrar(novoUsuario);
            return StatusCode(201, tipoUsuario);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }



    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        try
        {
            var tipoUsuarioAtualizado = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };

            _usuarioRepositoy.Atualizar(id, tipoUsuarioAtualizado);

            return StatusCode(204, tipoUsuario);
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
                _usuarioRepositoy.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

}
