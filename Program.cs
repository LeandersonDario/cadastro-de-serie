using System;

namespace Cadastro_de_series
{
    class Program
    { 
       static SerieRepositorio repositorio = new SerieRepositorio();  
        static void Main(string[] args)
        { 
           string OpcoesUsuario = ObterOpcoesUsuario();

            while (OpcoesUsuario.ToUpper() != "X")
            {
              switch (OpcoesUsuario)
              {
                case "1":
                  ListarSeries();
                break;
                case "2":
                  InserirSerie();
                break;
                case "3":
                  AtualizarSerie();
                break;
                case "4":
                  ExcluirSerie();
                break;
                case "5":
                  VisualizarSerie();
                break;
                case "C":
                  Console.Clear();
                break;

                default:
                 throw new ArgumentOutOfRangeException();
              }
              OpcoesUsuario = ObterOpcoesUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos sistema. Valeu");
            Console.ReadLine();
          }

        
      

        private static string ObterOpcoesUsuario()
        {
          Console.WriteLine();
          Console.WriteLine("Séries a seu dispor");
          Console.WriteLine("Informe a opção desejada");

          Console.WriteLine("1- lista de séries");
          Console.WriteLine("2- Inserir série");
          Console.WriteLine("3- Atualizar série");
          Console.WriteLine("4- Excluir série");
          Console.WriteLine("5- Visualizar série");
          Console.WriteLine("C- Limpar Tela");
          Console.WriteLine("X- Sair");
          Console.WriteLine();

          string OpcoesUsuario = Console.ReadLine().ToUpper();
          Console.WriteLine();
          return OpcoesUsuario;

        }

        private static void ListarSeries()
        {
          var lista = repositorio.Lista();

          if(lista.Count == 0)
          {
            Console.WriteLine("Nenhuma série cadastrada");
            return;
          }

          foreach (var serie in lista)
          {
            var excluido = serie.RetornaExcluido();
            
            Console.WriteLine($"#ID {0}: - {1} {2}", 
              serie.RetornaId(), 
              serie.RetornaTitulo(), 
              (excluido ? "*Excluido*": "" ));
          }
        }

        public static void InserirSerie()
        {
          foreach(var i in Enum.GetValues(typeof(Genero)))
          {
            Console.WriteLine($"#ID {0}: - {1}", i, Enum.GetName(typeof(Genero), i));
          }
          Console.WriteLine("Digite o genero");
          int EntradaGenero = int.Parse(Console.ReadLine());

          Console.WriteLine("Digite o título da serie");
          string EntradaTitulo = Console.ReadLine();

          Console.WriteLine("Digite o ano de iniciao");
          int EntradaAno = int.Parse(Console.ReadLine());
                
          Console.WriteLine("Digite  a descrição");
          string EntradaDescricao = Console.ReadLine();

          Serie  NovaSerie = new Serie(id: repositorio.ProximoId(),
            genero: (Genero)EntradaGenero,
            titulo: EntradaTitulo,
            ano: EntradaAno,
            descricao: EntradaDescricao);

          repositorio.Insere(NovaSerie);
        }

        private static void AtualizarSerie()
       {
         Console.WriteLine("Digite o id");
         int indiceSerie = int.Parse(Console.ReadLine());

         foreach (var i in Enum.GetValues(typeof(Genero)))
         {
          Console.WriteLine($"#ID {0}: - {1}", i, Enum.GetName(typeof(Genero), i));
         }
         Console.WriteLine("Digite o genero");
        int EntradaGenero = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o título da serie");
        string EntradaTitulo = Console.ReadLine();

        Console.WriteLine("Digite o ano de inicio");
        int EntradaAno = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite  a descrição");
        string EntradaDescricao = Console.ReadLine();

        Serie AtualizaSerie = new Serie(id: indiceSerie,
          genero: (Genero)EntradaGenero,
          titulo: EntradaTitulo,
          ano: EntradaAno,
          descricao: EntradaDescricao);

        repositorio.Atualizar(indiceSerie, AtualizaSerie);
       }    
       private static void ExcluirSerie()
       {
         Console.WriteLine("Digite o id da serie: ");
         int indiceSerie = int.Parse(Console.ReadLine());

         repositorio.Excluir(indiceSerie);
       }

       private static void VisualizarSerie()
       {
         Console.WriteLine("Digite o id da serie: ");
         int indiceSerie = int.Parse(Console.ReadLine());

         var serie = repositorio.RetornaPorId(indiceSerie);

         Console.WriteLine(serie);
      } 
   }
}
