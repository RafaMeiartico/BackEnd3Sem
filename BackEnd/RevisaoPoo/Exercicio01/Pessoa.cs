namespace Exercicio01
{
    public class Pessoa
    {
        public string Nome;

        private int idade;

        // Exercicio 3
        public int Idade
        {
            get { return idade; }

            set
            {
                if (value > 0)
                {
                    idade = value;
                }
                else
                {
                    Console.WriteLine("Idade inválida, tente novamente!");
                }
            }
        }

        //Exercicio 4 - Construtor 
        public Pessoa (String nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        //Exercicio 6 - Sobrecarga

        public void Apresentar()
        {
            Console.WriteLine($"Olá, meu nome é {Nome}");
            
        }
        public void Apresentar(string Sobrenome)
        {
            Console.WriteLine($"Olá, meu nome é {Nome} {Sobrenome}");
        }

        // Exercicio 2
        public virtual void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome} | Idade: {Idade}");
        }
    }
}