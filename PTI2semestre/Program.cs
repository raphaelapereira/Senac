namespace pti.algoritmo;

class Program
{
  public static string[,] listaprodutos = new string[30,30];
  static void Main(string[] args)
    {
      Console.WriteLine("");
      Console.WriteLine("************************************");
      Console.WriteLine("*                                  *");
      Console.WriteLine("*        SISTEMA DE ESTOQUE        *");
      Console.WriteLine("*           PARA PETSHOP           *");
      Console.WriteLine("*                                  *");
      Console.WriteLine("************************************");
      Console.WriteLine("");
      Console.WriteLine("");
      MenuProdutos();
    }

  //Função do menu
  public static void MenuProdutos()
    {
      int opcao;
      Console.WriteLine("O que você deseja fazer?");
      Console.WriteLine("[1] Novo");
      Console.WriteLine("[2] Listar produtos");
      Console.WriteLine("[3] Remover produtos");
      Console.WriteLine("[4] Entrada estoque");
      Console.WriteLine("[5] Saída estoque");
      Console.WriteLine("[0] Sair");

      opcao = int.Parse(Console.ReadLine());
      switch(opcao)
        {
          case 1: 
            NovoProduto();
            MenuProdutos();
          break;
          case 2: 
            ListarProduto();
            MenuProdutos();
          break;
          case 3: 
            RemoverProduto();
            MenuProdutos();
          break;
          case 4: 
            EntradaEstoque();
            MenuProdutos();
          break;
          case 5: 
            RemoverEstoque();
            MenuProdutos();
          break;
          case 0: 
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***************");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Autora: Raphaela F. P. Soares");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***************");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("Saindo..");
            Console.WriteLine("");
          break;
          default:
            Console.WriteLine("Opção inválida");
            MenuProdutos();
          break;
        }
    }

  //Função para cadastrar novo produto
  public static void NovoProduto()
    {
      string nomeproduto;
      string marcaproduto;
      double pesoproduto;
      double precoproduto;
      string quantidadeproduto;
      string especieproduto;
      Console.WriteLine("Nome do produto:");
      nomeproduto = Console.ReadLine();
      Console.WriteLine("Marca do produto:");
      marcaproduto = Console.ReadLine();
      Console.WriteLine("Preço do produto:");
      precoproduto = double.Parse(Console.ReadLine());
      Console.WriteLine("Peso do produto:");
      pesoproduto = double.Parse(Console.ReadLine());
      Console.WriteLine("Espécie do animal:");
      especieproduto = Console.ReadLine();
      quantidadeproduto = "0";

      for (int linha = 0; linha < listaprodutos.GetLength(0); linha++)
        {
          if (string.IsNullOrEmpty(listaprodutos[linha,0]))
            {
              listaprodutos[linha,0] = nomeproduto;
              listaprodutos[linha,1] = marcaproduto;
              listaprodutos[linha,2] = precoproduto.ToString();
              listaprodutos[linha,3] = pesoproduto.ToString();
              listaprodutos[linha,4] = especieproduto;
              listaprodutos[linha,5] = quantidadeproduto;
              break;
            }
      }
      Console.WriteLine("");
    }

  //Função para listar os produtos
  public static void ListarProduto()
    {
      int index = 1;

      Console.WriteLine("");
      Console.WriteLine("| Codigo | Nome do Produto | Marca do Produto | Preço | Peso | Especie Animal | Estoque |");
      for (int linha = 0; linha < listaprodutos.GetLength(0); linha++)
        {
          if (!string.IsNullOrEmpty(listaprodutos[linha,0]))
            {
              Console.WriteLine(string.Format("|{0,-8}|{1,-17}|{2,-18}|{3,-7:C}|{4,-6}|{5,-16}|{6,-9}|", " " + index, " " + listaprodutos[linha,0], " " + listaprodutos[linha,1], " " + listaprodutos[linha,2], " " + listaprodutos[linha,3], " " + listaprodutos[linha,4], " " + listaprodutos[linha,5]));
              //Console.WriteLine(index + ". " + listaprodutos[linha,0] + "(R$ " + listaprodutos[linha,2] + ") - " + listaprodutos[linha,5] + " no estoque"); 
              index ++;
            }
        }
        Console.WriteLine("");
    }

  //Função de remover produtos
  public static void RemoverProduto()
    {
      int index = 1;

      Console.WriteLine("");
      Console.WriteLine("Informe o código do produto:");
      int remover = int.Parse(Console.ReadLine());
      for (int linha = 0; linha < listaprodutos.GetLength(0); linha++)
        {
          if (!string.IsNullOrEmpty(listaprodutos[linha,0]))
            {
              if (remover == index)
                {
                  listaprodutos[linha,0] = null;
                  listaprodutos[linha,1] = null;
                  listaprodutos[linha,2] = null;
                  listaprodutos[linha,3] = null;
                  listaprodutos[linha,4] = null;
                  listaprodutos[linha,5] = null;
                }
              index ++;
            }
        }
        Console.WriteLine("");
    }

  //Função de entrada estoque
  public static void EntradaEstoque()
      {
        int index = 1;

        Console.WriteLine("");
        Console.WriteLine("Informe o código do produto:");
        int adicionar = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        Console.WriteLine("Informe a quantidade:");
        int qtd = int.Parse(Console.ReadLine());
        for (int linha = 0; linha < listaprodutos.GetLength(0); linha++)
          {
            if (!string.IsNullOrEmpty(listaprodutos[linha,0]))
              {
                if (adicionar == index)
                  {
                    int qtdatual = Int32.Parse(listaprodutos[linha,5]);
                    int qtdfinal = qtdatual + qtd;
                    listaprodutos[linha,5] = qtdfinal.ToString();
                  }
                index ++;
              }
          }
          Console.WriteLine("");
      }

  //Função de saída estoque
  public static void RemoverEstoque()
        {
          int index = 1;

          Console.WriteLine("");
          Console.WriteLine("Informe o código do produto:");
          int remover = int.Parse(Console.ReadLine());
          Console.WriteLine("");
          Console.WriteLine("Informe a quantidade:");
          int qtd = int.Parse(Console.ReadLine());
          for (int linha = 0; linha < listaprodutos.GetLength(0); linha++)
            {
              if (!string.IsNullOrEmpty(listaprodutos[linha,0]))
                {
                  if (remover == index)
                    {
                      int qtdatual = Int32.Parse(listaprodutos[linha,5]);
                      int qtdfinal = qtdatual - qtd;
                      if (qtdfinal < 0)
                        {
                          Console.WriteLine("Estoque insuficiente!");
                          break;
                        }
                      listaprodutos[linha,5] = qtdfinal.ToString();
                    }
                  index ++;
                }
            }
            Console.WriteLine("");
        }
}
