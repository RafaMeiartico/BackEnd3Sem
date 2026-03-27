using ConnectPlus.Models;    
using Microsoft.AspNetCore.Http;
using ConnectPlus.BDConnectPlus;
using ConnectPlus.Interface;
using System.Net.Http.Headers;

namespace ConnectPlus.Repositories;

public class ContatoRepository : IContatoRepository
{
    private readonly ConnectPlusContext _context;

    public ContatoRepository(ConnectPlusContext context)
    {
        _context = context;
    }




    public void Atualizar(Guid id, Contato contato)
    {
        var Contato = _context.Contatos.Find(id);

        if (Contato != null)
        {
            Contato.IdTipoContato = contato.IdTipoContato;
            Contato.Titulo = contato.Titulo;
            Contato.Imagem = contato.Imagem;
            _context.SaveChanges();
        }
    }




    public Contato BuscarPorId(Guid IdContato)
    {
        try
        {
            Contato contatoBuscadoPorId = _context.Contatos.Find(IdContato.ToString())!;
            return contatoBuscadoPorId;

        }
        catch (Exception)
        {
            throw;
        }
    }




    public void Cadastrar(Contato contato)
    {
        try
        {
            contato.FormaContato = contato.FormaContato;
            contato.IdTipoContato = contato.IdTipoContato;
            contato.IdContato = Guid.NewGuid();

            _context.Contatos.Add(contato);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }




    public void Deletar(Guid id)
    {
        try
        {
            Contato contato = _context.Contatos.Find(id)!;

            if (contato != null)
            {
                _context.Contatos.Remove(contato);
            }

            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }




    public List<Contato> Listar()
    {
        try
        {
            List<Contato> ListarContatos = _context.Contatos.ToList();
            return ListarContatos;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
