using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Threading.Tasks;

namespace exercicio08
{
    public interface IAutenticavel
    {
        bool Autenticar(string senha);

    }
}