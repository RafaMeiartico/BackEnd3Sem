using FIlmesMoura.WebAPI.Interface;
using FIlmesMoura.WebAPI.Models;
using FIlmesMoura.WebAPI.NovaPasta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FIlmesMoura.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    public LoginController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost]

    public IActionResult Login(LoginDTO LoginDto)
    {
        try
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(LoginDto.Email!, LoginDto.Senha!);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou Senha inválidos");
            }

            //Caso encontre um usuário, prossegue para a criação do token

            //1 - Definir as informações (Claims) que serão fornecidas no token

            var claims = new[]
            { 
                //formato da claim
            new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario),
            new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!)

            //existe a possibilidade de criar uma claim personalizada
            //new Claim("Claim Personalizada", "Valor da Claim")
            };

            //2 - Definir a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

            //3 - Definir as credenciais do token (HEADER)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //4 - Gerar Token 
            var token = new JwtSecurityToken(issuer: "api_filmes",

                audience: "api_filmes",

                claims: claims,

                expires: DateTime.Now.AddMinutes(5),

                signingCredentials: creds
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }


        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
