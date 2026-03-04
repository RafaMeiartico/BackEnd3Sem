using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio01
{
 public class Funcionario : Pessoa
    {
        public float Salario;

        public Funcionario(string nome, int idade) : base(nome, idade)
        {
        }

        public override void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome} | Idade: {Idade} | Salário: R$: {Salario}");
        }
    }
}