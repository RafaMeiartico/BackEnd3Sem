using FIlmesMoura.WebAPI.Models;

namespace FIlmesMoura.WebAPI.Interface;

public interface IGeneroRepository
{
    Genero BuscaPorId(Guid id);
    List<Genero> Listar();
    void Cadastrar(Genero novoGenero);
    void Deletar(Guid id);
    void AtualizarIdCorpo(Genero generoAtualizado);
    void AtualizarIdUrl(Guid id, Genero generoAtualizado);
}
