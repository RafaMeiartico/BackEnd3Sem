using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class TipoUsuarioRepository : ITipoUsuarioRepository
{
    private readonly EventContext _context;
    private object TipoUsuario;

    public TipoUsuarioRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza o nome do usuário
    /// </summary>
    /// <param name="id">o id do usuário a ser atualizado</param>
    /// <param name="tipoUsuario">Novos dados do usuário</param>

    public void Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        var TipoUsuario = _context.TipoUsuarios.Find(id);

        if (TipoUsuario != null) 
        {
            tipoUsuario.Titulo = tipoUsuario.Titulo;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca um usuário por Id
    /// </summary>
    /// <param name="id">id do usuário a ser buscado</param>
    /// <returns></returns>

    public TipoUsuario BuscarPorId(Guid id)
    {
        return _context.TipoUsuarios.Find(id)!;
    }

    /// <summary>
    /// Cadastra um usuário
    /// </summary>
    /// <param name="id">Usuário a ser cadastrado</param>
    /// 
    public void Cadastrar(TipoUsuario tipoUsuario)
    {
        _context.TipoUsuarios.Add(tipoUsuario);
        _context.SaveChanges();
    }

   /// <summary>
   /// Deleta o=um usuário cadastrado
   /// </summary>
   /// <param name="id">id do usuario a ser deletado</param>

    public void Deletar(Guid id)
    {
        var tipoUsuario = _context.TipoUsuarios.Find(id);

        if (tipoUsuario != null)
        {
            _context.TipoUsuarios.Remove(tipoUsuario);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca o nome de um usuário
    /// </summary>
    /// <returns>Lista de Instituiçoes</returns>
    public List<TipoUsuario> Listar()
    {
        return _context.TipoUsuarios
            .OrderBy(TipoUsuario => TipoUsuario.Titulo)
            .ToList();
    }
}
