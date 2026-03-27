using ConnectPlus.DTO;
using ConnectPlus.Interface;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConnectPlus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoController(IContatoRepository contatoRepository)
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
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }




    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_contatoRepository.BuscarPorId(id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }

    }





    [HttpPost]

    public async Task<IActionResult> Cadastrar([FromForm] ContatoDTO novoContato)
    {
        if (string.IsNullOrWhiteSpace(novoContato.Titulo) && novoContato.FormaContato != null)
            return BadRequest("É necessário que o contato tenha Nome e o o tipo de contato (profissional, pessoal ou família.)");

        Contato contato = new Contato();

        if (novoContato.Imagem != null && novoContato.Imagem.Length > 0)
        {
            var extensao = Path.GetExtension(novoContato.Imagem.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await novoContato.Imagem.CopyToAsync(stream);
            }

            contato.Imagem = nomeArquivo;
        }

        contato.Titulo = novoContato.Titulo!;
        contato.FormaContato = novoContato.FormaContato!;
        contato.IdTipoContato = novoContato.IdTipoContato;

        try
        {
            _contatoRepository.Cadastrar(contato);
            return StatusCode(201);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }





    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, Contato contato)
    {
        try
        {
            _contatoRepository.Atualizar(id, contato);
            return NoContent();
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
