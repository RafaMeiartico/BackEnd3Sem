using FIlmesMoura.WebAPI.BdContextFilme;
using FIlmesMoura.WebAPI.Interface;
using FIlmesMoura.WebAPI.Models;
using FIlmesMoura.WebAPI.Utils;

namespace FIlmesMoura.WebAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly FilmeContext _context;

    public UsuarioRepository (FilmeContext context)
    {
        _context = context;
    }

    public Usuario BuscarPorEmailESenha(string email, string senha)
    {
        try
        {
            Usuario usuarioBuscado = _context.Usuarios.FirstOrDefault(u => u.Email == email)!;

            if (usuarioBuscado != null)
            {
                bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha);

                if (confere) 
                {
                    return usuarioBuscado;
                }
            }
            return null!;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public Usuario BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Cadastrar(Usuario NovoUsuario)
    {
        try
        {
            NovoUsuario.IdUsuario = Guid.NewGuid().ToString();

            NovoUsuario.Senha = Criptografia.GerarHash(NovoUsuario.Senha);

            _context.Usuarios.Add(NovoUsuario);
            _context.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
