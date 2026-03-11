using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.DTO;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{
    private IInstituicaoRepository _instituicaoRepository;

    public InstituicaoController(IInstituicaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }



    [HttpGet] //get normal

    public IActionResult Listar()
    {
        try
        {
            return Ok(_instituicaoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


    [HttpGet("{id}")] //get por id
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_instituicaoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }




    [HttpPost]

    public IActionResult Cadastrar(InstituicaoDTO instituicao)
    {
        try
        {
            var novaInstituicao = new Instituicao
            {
                 NomeFantasia = instituicao.Titulo!
            };

            _instituicaoRepository.Cadastrar(novaInstituicao);
            return StatusCode(201, Instituicao);

        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


    [HttpPut("{id}")]

    public IActionResult Atualizar(Guid id, Instituicao instituicao)
    {
        try
        {
            var InstituicaoAtualizada = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia!
            };

            _instituicaoRepository.Atualizar(id, InstituicaoAtualizada)

            return StatusCode(204, instituicao);

        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }

        []
    
    }

}

