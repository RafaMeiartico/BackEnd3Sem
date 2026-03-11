using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class InstituicaoRepository : IInstituicaoRepository
{

    private readonly EventContext _context;
    private object instituicao;

    public InstituicaoRepository(EventContext context)
    { 
        _context = context;
    }

    /// <summary>
    /// Atualiza o nome de uma instituição
    /// </summary>
    /// <param name="id">o id da Instituição a ser atualizado</param>
    /// <param name="instituicao">Novos dados da instituição</param>


    public void Atualizar(Guid id, Instituicao instituicao)
    {
        var Instituicao = _context.Instituicaos.Find(id);

        if(Instituicao != null)
        { 

            Instituicao.Endereco = instituicao.Endereco;
            instituicao.Cnpj = Instituicao.Cnpj;
            Instituicao.NomeFantasia = instituicao.NomeFantasia;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca uma instituição por Id
    /// </summary>
    /// <param name="id">id da instuição a ser buscado</param>
    /// <returns></returns>

    public Instituicao BuscarPorId(Guid id)
    {
        return _context.Instituicaos.Find(id)!;
    }

    /// <summary>
    /// Cadastra uma nova Instituição
    /// </summary>
    /// <param name="instituicao"><Instituição a ser cadastrada/param>

    public void Cadastrar(Instituicao instituicao)
    {
        _context.Instituicaos.Add(instituicao);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta uma Instituição
    /// </summary>
    /// <param name="id">id da instituição a ser deletado</param>

    public void Deletar(Guid id)
    {
        var instituicao = _context.Instituicaos.Find(id);

        if (instituicao != null)
        {
            _context.Instituicaos.Remove(instituicao);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca o nome fantasia de Instituições cadastradas
    /// </summary>
    /// <returns>Lista de Instituições</returns>

    public List<Instituicao> Listar()
    {
        return _context.Instituicaos
            .OrderBy(Instituicao => Instituicao.NomeFantasia)
            .ToList();
    }
}
