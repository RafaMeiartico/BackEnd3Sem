using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class ComentarioEventoRepository : IComentarioEventoRepository
{
    private readonly EventContext _Context;
    public ComentarioEventoRepository(EventContext context)
    {
        _Context = context;
    }



    public void Cadastrar(ComentarioEvento comentario)
    {
        _Context.ComentarioEventos.Add(comentario);
        _Context.SaveChanges();
    }
    


      public void Deletar(Guid IdComentario)
    {
        var comentarioBuscado = _Context.ComentarioEventos.Find(IdComentario);
        if (comentarioBuscado != null)
        {
            _Context.ComentarioEventos.Remove(comentarioBuscado);
            _Context.SaveChanges();
        }

    }



    public List<ComentarioEvento> Listar(Guid IdEvento)
    {
        return _Context.ComentarioEventos.Where(c => c.IdEvento == IdEvento).ToList();

    }




    public ComentarioEvento BuscarPorIdUsuario(Guid IdEvento)
    {
        throw new NotImplementedException();
    }

   

    public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
    {
        return _Context.ComentarioEventos
            .Where(c => c.IdEvento == IdEvento && c.Exibe)
            .OrderByDescending(c => c.DataComentarioEvento)
            .ToList();
    }

    public ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdEvento)
    {
        throw new NotImplementedException();
    }
}
