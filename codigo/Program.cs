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

            QuantidadeDeJogadores();
            IniciarPartidas();
            //FinalizarPrograma();
        }

        static void IniciarPartidas()
        {
            char resp = 's';

            Partida partida;
            while (resp != 'n')
            {
                partida = new Partida(jogadores, QuantidadeDeBaralho());
                partida.IniciarPartida();
                ExibirHistoricoJogador();
                Console.WriteLine("\nDeseja iniciar uma nova partida? - s / n");// talvez algo parecido com um menu ficaria menhor, tem que fazer o tratamento das alternativas

                resp = char.Parse(Console.ReadLine());
            }
        }

        static void ExibirHistoricoJogador()
        {
            char resp = 's';
            string nome = "";
            Console.WriteLine("\nDeseja visualizar o histórico de algum jogador em específico? - s / n"); // talvez algo parecido com um menu ficaria menhor, tem que fazer o tratamento das alternativas
            resp = char.Parse(Console.ReadLine());
            resp = char.ToUpper(resp);


            if (resp == 'S')
            {
                Console.WriteLine($"Digite o nome do jogador que deseja pesquisar:");//tratamento de nome errado
                nome = Console.ReadLine();

                for (int i = 0; i < jogadores.Length; i++)
                {
                    if (jogadores[i].Nome == nome)
                    {
                        Console.WriteLine($"Rank do {jogadores[i].Nome}\n{jogadores[i].ExibirRank()}");
                    }
                }
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

                jogadores[i] = new Jogador(nome);

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
