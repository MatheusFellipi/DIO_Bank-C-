using System;
using System.Collections.Generic;
namespace bank
{
  class Program
  {
    static List<Conta> listaContas = new List<Conta>();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarContas();
            break;
          case "2":
            InserirConta();
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
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }

      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.ReadLine();
    }

    private static void Depositar()
    {
      Console.Write("digital o numero da conta: ");
      int indeceConta = int.Parse(Console.ReadLine());

      Console.Write("Digital o valor a ser sacado: ");
      double valorSacar = double.Parse(Console.ReadLine());

      listaContas[indeceConta].Depositar(valorSacar);
    }

    private static void Sacar()
    {
      Console.Write("digital o numero da conta: ");
      int indeceConta = int.Parse(Console.ReadLine());

      Console.Write("Digital o valor a ser sacado: ");
      double valorSacar = double.Parse(Console.ReadLine());

      listaContas[indeceConta].Sacar(valorSacar);
    }

    private static void ListarContas()
    {
      Console.WriteLine("Listar contas");

      if (listaContas.Count == 0)
      {
        Console.WriteLine("Nenhuma cont cadastrada.");
        return;
      }

      for (int i = 0; i < listaContas.Count; i++)
      {
        Conta conta = listaContas[i];
        Console.WriteLine("#{0} - ", i);
        Console.WriteLine(conta);
      }
    }

    private static void Transferir()
    {
      Console.Write("Digite o número da conta de origem: ");
      int indiceContaOrigem = int.Parse(Console.ReadLine());

      Console.Write("Digite o número da conta de destino: ");
      int indiceContaDestino = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser transferido: ");
      double valorTransferencia = double.Parse(Console.ReadLine());

      listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
    }
    private static void InserirConta()
    {
      Console.WriteLine("Inserir nova conta");

      Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
      int entradaTipoConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o Nome do Cliente: ");
      string entradaNome = Console.ReadLine();

      Console.Write("Digite o saldo inicial: ");
      double entradaSaldo = double.Parse(Console.ReadLine());

      Console.Write("Digite o crédito: ");
      double entradaCredito = double.Parse(Console.ReadLine());

      Conta novaConta = new Conta(TipoConta: (TipoConta)entradaTipoConta,
                    saldo: entradaSaldo,
                    credito: entradaCredito,
                    nome: entradaNome);

      listaContas.Add(novaConta);
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Bank a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar contas");
      Console.WriteLine("2- Inserir nova conta");
      Console.WriteLine("3- Transferir");
      Console.WriteLine("4- Sacar");
      Console.WriteLine("5- Depositar");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }

}
