using System.Text;
using static Rouba_Monte.Tela;
using static Rouba_Monte.Parada;

namespace Rouba_Monte
{
    internal class Program
    {
        static Jogador[] jogadores;

        static void Main()
        {
            Cabecalho();

            Inicio();
        }

        static void Menu1()
        {
            Cabecalho();

            Console.WriteLine($"Opção");
            Console.WriteLine($"1 - Inicia o jogo.");
            Console.WriteLine($"0 - sair.");
        }

        static void Menu2()
        {
            Cabecalho();

            Console.WriteLine($"Opção");
            Console.WriteLine($"1 - Inicia uma nova partida.");
            Console.WriteLine($"2 - Ver historido de um jogador.");
            Console.WriteLine($"0 - sair.");
        }

        static void ProcessarFimDeJogo()
        {
            int opcao;
            string text = "Saindo!!!";

            do
            {
                Menu2();

                Console.WriteLine($"Digite uma opção:\n");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Esperar(text);
                        break;
                    case 1:
                        IniciarPartidas();
                        break;
                    case 2:
                        ExibirHistoricoJogador();
                        break;
                }
            } while (opcao != 0);
        }

        static void IniciarPartidas()
        {
            Partida partida;

            partida = new Partida(jogadores, QuantidadeDeBaralho());
            partida.IniciarPartida();

        }

        static void Inicio()
        {
            int opcao;
            Partida partida;
            string text = "Saindo!!!";
            string text2 = "Opção invalida!!!";

            do
            {
                Menu1();

                Console.WriteLine($"Digite uma opção:\n");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Esperar(text);
                        break;
                    case 1:
                        QuantidadeDeJogadores();
                        partida = new Partida(jogadores, QuantidadeDeBaralho());
                        partida.IniciarPartida();
                        ProcessarFimDeJogo();
                        break;
                    default:
                        Esperar(text2);
                        break;
                }
            } while (opcao != 0 && opcao != 1);

        }

        static void ExibirHistoricoJogador()
        {
            string nome;
            bool achouNome = false;

            Cabecalho();
            Console.WriteLine($"Digite o nome do jogador que deseja pesquisar:");
            nome = Console.ReadLine();

            for (int i = 0; i < jogadores.Length; i++)
            {
                if (jogadores[i].Nome == nome.ToLower())
                {
                    achouNome = true;
                    Cabecalho();
                    Console.WriteLine($"Rank do {jogadores[i].Nome}\n{jogadores[i].ExibirRank()}");
                }
            }

            if (!achouNome)
            {
                Console.WriteLine($"Jogador {nome} não foi encontrado!!!");
            }

        }

        static void QuantidadeDeJogadores()
        {
            int numDeJogadores;
            string mensagemErro = "Número de jogadores insuficiente!!!";

            do
            {
                Cabecalho();

                Console.WriteLine($"Quantos Jogadores vão jogar?");
                numDeJogadores = Convert.ToInt32(Console.ReadLine());

                if (numDeJogadores < 2)
                {
                    Esperar(mensagemErro);
                }

            } while (numDeJogadores < 2);

            jogadores = new Jogador[numDeJogadores];

            NomeDosJogadores();
        }

        static void NomeDosJogadores()
        {
            string nome;
            string mensagemErro = "Nome do Jogador não pode ser nulo!!!";

            for (int i = 0; i < jogadores.Length; i++)
            {
                do
                {
                    Cabecalho();
                    Console.WriteLine($"Digite o nome do Jogador {i + 1}:");
                    nome = Convert.ToString(Console.ReadLine());

                    if (nome == "" || nome == null)
                    {
                        Esperar(mensagemErro);
                    }

                } while (nome == "" || nome == null);

                jogadores[i] = new Jogador(nome.ToLower());

            }
        }

        static MonteDoJogo QuantidadeDeBaralho()
        {
            int numDeBaralho;
            string mensagemErro = "Número de Baralho insuficiente!!!";

            do
            {
                Cabecalho();

                Console.WriteLine($"Quantos Baralhos vão ter o jogo?");
                numDeBaralho = Convert.ToInt32(Console.ReadLine());

                if (numDeBaralho < 1)
                {
                    Esperar(mensagemErro);
                }

            } while (numDeBaralho < 1);

            return new MonteDoJogo(numDeBaralho);
        }
    }
}
