using ConnectPlus.Models;

namespace ConnectPlus.Interface;

public interface IContatoRepository
{
    void Cadastrar(Contato contato);
    void Deletar(Guid id);
    List<Contato> Listar();
    Contato BuscarPorId(Guid IdContato);
    void Atualizar(Guid id, Contato contato);

}
