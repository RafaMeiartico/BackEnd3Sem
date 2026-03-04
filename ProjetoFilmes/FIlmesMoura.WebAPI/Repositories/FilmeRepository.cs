using FIlmesMoura.WebAPI.BdContextFilme;
using FIlmesMoura.WebAPI.Interface;
using FIlmesMoura.WebAPI.Models;    

namespace FIlmesMoura.WebAPI.Repositories;

public class FilmeRepository : IFilmeRepository
{

    private readonly FilmeContext _context;

    public FilmeRepository(FilmeContext context)
    {
        _context = context;
    }
    public void AtualizarIdCorpo(Filme filmeAtualizado)
    {
        try
        {
            Filme filmeBuscado = _context.Filmes.Find(filmeAtualizado.IdFilme)!;
            if (filmeBuscado != null)
            {
                filmeBuscado.Titulo = filmeAtualizado.Titulo;
                filmeBuscado.IdGenero = filmeAtualizado.IdGenero;
            }
            _context.Filmes.Update(filmeBuscado!);
            _context.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void AtualizarIdUrl(Guid Id, Filme filmeAtualizado)
    {
        try
        {
            Filme filmeBuscado = _context.Filmes.Find(Id.ToString())!;
            if (filmeBuscado != null)
            {
                filmeBuscado.Titulo = filmeAtualizado.Titulo;
                filmeBuscado.IdGenero = filmeAtualizado.IdGenero;
            }

            _context.Filmes.Update(filmeBuscado!);
            _context.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public Filme BuscarPorId(Guid Id)
    {
        try
        {
            Filme filmeBuscando = _context.Filmes.Find(Id.ToString())!;
            return filmeBuscando;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public void Cadastrar(Filme novoFilme)
    {
        try
        {

            novoFilme.IdFilme = Guid.NewGuid().ToString();

            _context.Filmes.Add(novoFilme);
            _context.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void Deletar(Guid Id)
    {
        try
        {
            Filme filmeBuscado = _context.Filmes.Find(Id.ToString())!;

            if (filmeBuscado != null)
            {
                _context.Filmes.Remove(filmeBuscado);
            }

            _context.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public List<Filme> Listar()
    {
        try
        {
            List<Filme> ListarFilmes = _context.Filmes.ToList();
            return ListarFilmes;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
