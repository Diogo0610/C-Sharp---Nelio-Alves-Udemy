using System;

namespace Cadastramento_de_conta___Aula_60
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria conta;

            Console.Write("Entre o número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Entre o Titular da conta: ");
            string titular = Console.ReadLine();
            Console.Write("Haverá depósito inicial (s/n)? ");
            char resposta = char.Parse(Console.ReadLine());

            if (resposta == 's'|| resposta == 'S')
            {
                Console.Write("Digite o valor do depósito inicial: ");
                double depInicial = double.Parse(Console.ReadLine());

                conta = new ContaBancaria(numero, titular, depInicial);
            }
            else
            {
                conta = new ContaBancaria(numero, titular);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(conta);
            Console.WriteLine();

            Console.Write("Entre um valor para depósito: ");
            double valorDep = double.Parse(Console.ReadLine());
            conta.Depositar(valorDep);
            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(conta);
            Console.WriteLine();

            Console.Write("Entre um valor para saque: ");
            double valorSaq = double.Parse(Console.ReadLine());
            conta.Sacar(valorSaq);
            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(conta);

        }
    }
}
