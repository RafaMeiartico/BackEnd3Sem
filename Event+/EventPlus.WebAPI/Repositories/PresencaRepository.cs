using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class PresencaRepository : IPresencaRepository
{
    public readonly EventContext _context;

    public PresencaRepository(EventContext context)
    {
        _context = context;
    }


    /// <summary>
    /// Método alterna a situação da presença
    /// </summary>
    /// <param name="id">id da presença a ser alterada</param>
    public void Atualizar(Guid id)
    {
        var presencaBuscada = _context.Presencas.Find(id);

        if (presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;

            _context.SaveChanges();
        }
    }





    /// <summary>
    /// Método que busca uma presença por id
    /// </summary>
    /// <param name="id">id da presença a ser buscada</param>
    /// <returns>presença buscada</returns>
    public Presenca BuscarPorId(Guid id)
    {
        return _context.Presencas
            .Include(p => p.IdEventoNavigation)
                .ThenInclude(e => e!.IdInstituicaoNavigation)
            .FirstOrDefault(p => p.IdPresenca == id)!;
    }




    /// <summary>
    /// Inscreve  uma presença
    /// </summary>
    /// <param name="presenca">id de uma presenca a ser cadastrada</param>
    public void Inscrever(Presenca presenca)
    {
        _context.Presencas.Add(presenca);
        _context.SaveChanges();
    }

    
    
    
    
    /// <summary>
    /// Deleta uma presença
    /// </summary>  
    /// <param name="id">id da presença a ser deletada</param>
    public void Deletar(Guid id)
    {
        var presencaBuscada = _context.Presencas.Find(id);

        if (presencaBuscada != null)
        {
            _context.Presencas.Remove(presencaBuscada);
            _context.SaveChanges();
        }
    }




    /// <summary>
    /// Lista as presenças
    /// </summary>
    /// <returns></returns>

    public List<Presenca> Listar()
    {
        return _context.Presencas
            .OrderBy(Presenca => Presenca.Situacao)
            .ToList();
    }





    /// <summary>
    /// Método que lista as presenças de um usuário específico
    /// </summary>
    /// <param name="IdUsuario">id do usuário para filtragem</param>
    /// <returns>Lista de presenças de um usuário</returns>
    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return _context.Presencas
            .Include(p => p.IdEventoNavigation)
                .ThenInclude(e => e!.IdInstituicaoNavigation)
            .Where(p => p.IdUsuario == IdUsuario)
            .ToList();
    }
}
