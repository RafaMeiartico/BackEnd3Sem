using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercicio08
{
    public class Administrador : IAutenticavel
    {
        private string senhaAdm = "123";

        public bool Autenticar(string senha)
        {
            if (senha == senhaAdm)
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