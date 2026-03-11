using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public interface IEventoRepository
{
    void Cadastrar(Evento evento);
    void Deletar(Guid id);
    List<Evento> Listar();
    Instituicao BuscarPorId(Guid id);
    void Atualizar(Guid id, Evento evento);
    List<Evento> ListarPorId(Guid IdUsuario);
    List<Evento> ListarProximos();
}
