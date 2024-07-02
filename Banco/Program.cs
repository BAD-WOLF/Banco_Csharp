using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;

namespace Banco
{
  public static class Program
  {
    private static Cadastro Cadastrador { get; set; }
    private static int _setOption;
    private static string _titular;
    private static float _preco;
    private static float _saque;
    private static List<int> _opcoes;
    private enum TypeAsk
    {
      AskTitularPreco,
      AskSaque
    }

    public static void Main(string[] argv)
    {
      Program._opcoes = new List<int> { 0, 1, 2, 3 };
      Program.Menu();
      Program.Ask(Program.TypeAsk.AskTitularPreco);
      Program.Cadastrador = new Cadastro(Program._titular, Program._preco);

      while (true)
      {
        Program.Menu();
        switch (Program._setOption)
        {
          case 0:
            Program.Ask(Program.TypeAsk.AskTitularPreco);
            Program.Cadastrador.NomeTitular = Program._titular;
            Program.Cadastrador.CurrentValue = Program._preco;
            break;

          case 1:
            Console.Write("Nome do titular >> ");
            Program._titular = Console.ReadLine();
            Program.Cadastrador = new Cadastro(Program._titular);
            break;

          case 2:
            Program.Ask(null);
            Program.Cadastrador.CurrentValue += Program._preco;
            break;

          case 3:
            Program.Ask(Program.TypeAsk.AskSaque);
            break;

          case 4:
            if (Program.Cadastrador != null)
            {
              Program.ShowData();
            }
            else Console.WriteLine("[err] vc nao cadastror um client");
            break;

          default:
            Console.WriteLine("opcao invalida!!");
            Program._setOption = -1;
            Thread.Sleep(3000); break;
        }

        Console.WriteLine("{{ operacao concluida }}");
        Thread.Sleep(3000);
        Console.Clear();
      }
      // ReSharper disable once FunctionNeverReturns
    }

    private static void Menu()
    {
      if (Program._setOption == -1 || (Program._setOption != 3 && Program._opcoes.Contains(Program._setOption)))
      {
        Console.Clear();
        Console.WriteLine("<< banco do vieira >>\n");
        Console.WriteLine(@"quer abri ou mostrar dadis da conta meu consagrado?
        [0] - editar conta ou abrir com valor inicial
        [1] - editar conta ou abrir sem valor inicial
        [2] - depositar valor
        [3] - retirar grana
        [4] - mostrar dados
        ");
        Console.Write(">> ");
        Program._setOption = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
      }
    }

    private static void Ask(Program.TypeAsk? whatAsk)
    {
      if (Program._setOption == -1 || (Program._setOption != 3 && Program._opcoes.Contains(Program._setOption)))
      {
        if (whatAsk == Program.TypeAsk.AskTitularPreco && Program._setOption != 2)
        {
          Console.Write("Nome do titular >> ");
          Program._titular = Console.ReadLine();
        }
        Console.Write("valor a depositar >> ");
        Program._preco = float.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
      }

      if (whatAsk == Program.TypeAsk.AskSaque)
      {
        Console.Write("valor a sacar >> ");
        Program._saque = float.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Cadastrador.CurrentValue -= Program._saque;
        Program._setOption = -1;
      }
    }

    private static void ShowData()
    {
      Console.Write("numero da conta: ");
      Console.WriteLine(Program.Cadastrador.NumeroConta);
      Console.Write("nome titular: ");
      Console.WriteLine(Program.Cadastrador.NomeTitular);
      Console.Write("valor inicial: ");
      Console.WriteLine(Program.Cadastrador.CurrentValue.ToString("F2", CultureInfo.InvariantCulture));
      Console.Write("V _ F: ");
      Console.WriteLine(Program.Cadastrador.VF);
      Program._setOption = -1;
    }
  }
}

