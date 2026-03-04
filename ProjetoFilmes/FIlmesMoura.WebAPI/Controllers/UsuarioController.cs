using FIlmesMoura.WebAPI.Interface;
using FIlmesMoura.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIlmesMoura.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost]

    public IActionResult Post(Usuario novoUsuario)
    {
        try
        {
            _usuarioRepository.Cadastrar(novoUsuario);
                return StatusCode(201, novoUsuario);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
