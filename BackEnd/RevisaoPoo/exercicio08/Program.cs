using exercicio08;

Usuario Rafa = new Usuario();
Administrador Bia = new Administrador();

Console.Write("Digite a senha do usuário: ");
string senhaDigitada = Console.ReadLine();

bool entrou = Rafa.Autenticar(senhaDigitada);

if (entrou)
{
    Console.WriteLine("Bem-vindo ao sistema!");
}
else
{
    Console.WriteLine("Acesso negado!");
}

Console.Write("Digite a senha do Adiministrador: ");
string senhaDigitadaAdm = Console.ReadLine();

bool dentro = Bia.Autenticar(senhaDigitadaAdm);

if (dentro)
{
    Console.WriteLine("Bem-vindo ao sistema!");
}
else
{
    Console.WriteLine("Acesso negado!");
}

