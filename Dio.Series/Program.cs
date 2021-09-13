using System;

namespace Dio.Series {
    class Program {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args) {

            string opcaoUsuario = ObterOpcaoDoUsuario();

            while (opcaoUsuario.ToUpper() != "X") {

                switch (opcaoUsuario) {

                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtulizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoDoUsuario();
            }
            
            Console.WriteLine("Obrigado pela preferência");
            Console.WriteLine();
        }

        private static void ListarSerie() {

            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0) {

                Console.WriteLine("Nenhuma Série cadastrada. ");
                return;
            }
            
            foreach (var serie in lista) {

                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido  ? "Excluido" : "" )); 
            }

        }

        public static void InserirSerie() {

            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero))) {

                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                            Genero: (Genero)entradaGenero,
                                            Titulo: entradaTitulo,
                                            Ano: entradaAno,
                                            Descricao: entradaDescricao);

            repositorio.Insere(novaSerie);         
        }

        public static void AtulizarSerie() {

            Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero))) {

                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atulizarSerie = new Serie(id: indiceSerie,
                                            Genero: (Genero)entradaGenero,
                                            Titulo: entradaTitulo,
                                            Ano: entradaAno,
                                            Descricao: entradaDescricao);

            repositorio.Atualizar(indiceSerie, atulizarSerie);
        }

        public static void ExcluirSerie() {

            Console.Write("Digite o id a Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        public static void VisualizarSeries() {

            Console.Write("Digite o id a Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string ObterOpcaoDoUsuario() {

            Console.WriteLine();
            Console.WriteLine("Dio Séries a seu Dispor!!!");
            Console.WriteLine("Informe a opção desejada:");


            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuairio = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuairio;

        }
    }
}
