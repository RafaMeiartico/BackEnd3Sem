using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly EventContext _context;

    public EventoRepository(EventContext context)
    {
        _context = context;
    }





    /// <summary>
    /// Atualiza o nome de um evento
    /// </summary>
    /// <param name="id">o id do evento a ser atualizado</param>
    /// <param name="instituicao">Novos dados do evento</param>

    public void Atualizar(Guid id, Evento evento)
    {
        var Evento = _context.Eventos.Find(id);

        if (Evento != null)
        {

            Evento.DataEvento = evento.DataEvento;
            Evento.ComentarioEventos = evento.ComentarioEventos;
            Evento.IdInstituicao = evento.IdInstituicao;
            Evento.Descricao = evento.Descricao;
            _context.SaveChanges();
        }
    }




    /// <summary>
    /// Busca um evento apartir do id
    /// </summary>
    /// <param name="id">id do evento a ser buscado</param>
    /// <returns></returns>
    Evento IEventoRepository.BuscarPorId(Guid id)
    {
        return _context.Eventos.Find(id)!;
    }




    /// <summary>
    /// Cadastra um novo evento
    /// </summary>
    /// <param name="evento">Evento cadastrado</param>
    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }




    /// <summary>
    /// Deleta um Evento
    /// </summary>
    /// <param name="id">id do evento a ser deletado</param>

    public void Deletar(Guid id)
    {
        var evento = _context.Eventos.Find(id);

        if (evento != null)
        {
            _context.Eventos.Remove(evento);
            _context.SaveChanges();
        }
    }


    /// <summary>
    /// Busca o nome dos eventos cadastrados
    /// </summary>
    /// <returns>Lista dos eventos</returns>

    public List<Evento> Listar()
    {
        return _context.Eventos
            .OrderBy(Evento => Evento.Nome)
            .ToList();
    }





    /// <summary>
    /// Método que lista eventos filtrando pelas presenças de um usuário
    /// </summary>
    /// <param name="IdUsuario">Id do usuário para filtragem</param>
    /// <returns>Lista de eventos filtrados por usuários </returns>

    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e => e.Presencas.Any(p => p.IdUsuario == IdUsuario && p.Situacao == true))
            .ToList();
    }





    /// <summary>
    /// Método que busca os próximos eventos que irão acontecer
    /// </summary>
    /// <returns>Lista de próximos eventos</returns>
    public List<Evento> ListarProximos()
    {
        return _context.Eventos
             .Include(e => e.IdTipoEventoNavigation)
             .Include(e => e.IdInstituicaoNavigation)
             .Where(e => e.DataEvento >= DateTime.Now)
             .OrderBy(e => e.DataEvento)
             .ToList();
    }


}
