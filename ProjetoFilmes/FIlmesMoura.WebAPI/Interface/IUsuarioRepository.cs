using FIlmesMoura.WebAPI.Models;

namespace FIlmesMoura.WebAPI.Interface;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario NovoUsuario);

    Usuario BuscarPorId(Guid id);
    Usuario BuscarPorEmailESenha(string email, string senha);
}
