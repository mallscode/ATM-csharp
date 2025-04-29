using System;

class exec
{
    static void Main()
    {
        double saldo = 1000;
        while (true) 
        {
            Console.Write("Caixa Eletrônico. \n1- Ver Saldo\n2- Depositar\n3- Sacar\n4- Sair\n-> ");
            string[] ver = { "ver saldo", "saldo", "ver", "1" };
            string[] depositar = { "depositar", "2", "depósito", "deposito" };
            string[] sacar = { "sacar", "saque", "3" };
            string[] sair = { "sair", "4", "saída", "saida" };
            string[] opcoes = ver.Concat(depositar).Concat(sacar).Concat(sair).ToArray();

            string escolha = Console.ReadLine().Trim().ToLower();
            if (opcoes.Contains(escolha))
            {
                if (ver.Contains(escolha))
                {
                    Console.WriteLine($"Saldo: R$ {saldo}.\n");
                }
                else if (depositar.Contains(escolha))
                {
                    Console.Write("Digite o valor que você quer depositar: ");
                    double dep;
                    if (double.TryParse(Console.ReadLine(), out dep))
                    {
                        saldo += dep;
                        Console.WriteLine($"R$ {dep} foi depositado no seu saldo.\n");
                    }
                    else
                    {
                        Console.Write("Um erro ocorreu. O valor que você inseriu não é um número. Tentar novamente? Digite Y para sim: ");
                        string resp = Console.ReadLine().Trim().ToLower();
                        if (resp != "y")
                        {
                            Console.WriteLine("Obrigado por utilizar.");
                            break;
                        }
                    }
                }
                else if (sacar.Contains(escolha))
                {
                    Console.Write("Digite o valor que você quer sacar: ");
                    double saque;
                    if (double.TryParse(Console.ReadLine(),out saque))
                    {
                        if (saldo>=saque)
                        {
                            saldo -= saque;
                            Console.WriteLine($"R$ {saque} foi sacado do seu saldo.\n");
                        }
                        else
                        {
                            Console.Write("Um erro ocorreu. O valor do seu saque é maior do que o valor dísponivel na conta. Tentar novamente? Digite Y para sim: ");
                            string resp = Console.ReadLine().Trim().ToLower();
                            if (resp != "y")
                            {
                                Console.WriteLine("Obrigado por utilizar.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.Write("Um erro ocorreu. O valor que você inseriu não é um número. Tentar novamente? Digite Y para sim: ");
                        string resp = Console.ReadLine().Trim().ToLower();
                        if (resp != "y")
                        {
                            Console.WriteLine("Obrigado por utilizar.");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Obrigado por utilizar.");
                    break;
                }
            }
            else
            {
                Console.Write("Um erro ocorreu. Digite alguma das opções. Tentar novamente? Digite Y para sim: ");
                string resp = Console.ReadLine().Trim().ToLower();
                if (resp!="y")
                {
                    Console.WriteLine("Obrigado por utilizar.");
                    break;
                }
            }
        }
    }
}