using System;
using System.Collections.Generic;

namespace DIO.BANK
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(); ;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void InserirContas()
        {
            Console.WriteLine("Inserir Nova Conta: ");
            
            Console.Write("Digite 1 para PF ou 2 para PJ: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o Crédito Inicial: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoconta: (TipoConta) entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listaContas.Add(novaConta);
        }
        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada");
                return;
            }
            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ",i);
                Console.WriteLine(conta);
            }
        }
        private static void Sacar()
        {
            Console.Write("Digite o número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }
        private static void Depositar()
        {
            Console.Write("Digite o número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser Depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }
        private static void Transferir()
        {
            Console.Write("Digite o número da Conta Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o número da Conta Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser Transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Trasnferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO BANK a seu dispor!!");
            Console.WriteLine("Informe a opção desejada:: ");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;

        }
    }
}
