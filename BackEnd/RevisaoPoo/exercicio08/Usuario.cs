using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace exercicio08
{
    public class Usuario : IAutenticavel
    {
        private string senhaUser = "user";

        public bool Autenticar(string senha)
        {
            if (senha == senhaUser)
            {
                Console.WriteLine("Senha correta!");
                return true;
            }
            else
            {
                Console.WriteLine("Tente novamente!");
                return false;
            }
        }
    }
}