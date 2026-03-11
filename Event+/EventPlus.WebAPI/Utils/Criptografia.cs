using System.Globalization;

namespace EventPlus.WebAPI.Utils;

public class Criptografia
{
    public static string GerarHash(string senha) //pega uma senha e retorna ela criptograda
    { 
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }

    public static bool CompararHash(string senhaInformada, string senhaBanco)
    {
        return BCrypt.Net.BCrypt.Verify(senhaInformada, senhaBanco);
    }
}
