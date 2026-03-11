using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class TipoEventoRepository : ITipoEventoRepository
{
    private readonly EventContext _context;
    private object tipoEventoBuscado;

    //Injeção de dependencia: Recebe o contexto pelo construtor
    public TipoEventoRepository(EventContext context)
    { 
        _context = context;
    }

    /// <summary>
    /// Atualiza um tipo de evento usado o rastreamento automático
    /// </summary>
    /// <param name="id">id do tipo evento a ser atualizado</param>
    /// <param name="tipoEvento">Novos dados do tipo evento</param>

    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        var TipoEventoBuscado = _context.TipoEventos.Find(id);

        if (TipoEventoBuscado != null)
        {
           TipoEventoBuscado.Titulo = tipoEvento.Titulo; 
            
            //o savechanges detecta a mudança na propriedade "Titulo" automaticamente
            _context.SaveChanges();
        }

    }

    /// <summary>
    /// Busca um tipo de evento por Id
    /// </summary>
    /// <param name="id">id do tipo evento a ser buscado</param>
    /// <returns>Objeto do tipoEvento com as informações do tipo evento buscado</returns>

    public TipoEvento BuscarPorId(Guid id)
    {
        return _context.TipoEventos.Find(id)!;
    }

    /// <summary>
    /// Cadastra um novo tipo de evento
    /// </summary>
    /// <param name="tipoEvento">Tipo de evento a ser cadastrado</param>

    public void Cadastrar(TipoEvento tipoEvento)
    {
        _context.TipoEventos.Add(tipoEvento);
        _context.SaveChanges();
    }

    //documentação

    /// <summary>
    /// Deleta um tipo de evento
    /// </summary>
    /// <param name="id">id do tipo evento a ser deletado</param>

    public void Deletar(Guid id)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);

        if (tipoEventoBuscado != null)
        {
            _context.TipoEventos.Remove(tipoEventoBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de tipo de eventos cadastrados
    /// </summary>
    /// <returns>Uma lista de eventos</returns>

    public List<TipoEvento> Listar()
    {
        return _context.TipoEventos
            .OrderBy(TipoEvento => TipoEvento.Titulo)
            .ToList();
    }
}
