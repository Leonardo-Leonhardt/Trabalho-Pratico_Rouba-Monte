using System.Text;

namespace Rouba_Monte
{
    internal class Program
    {
        static Jogador[] jogadores;

        static int tempoDeEsperar = 5000;

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
            while(resp != 'n')
            {
                partida = new Partida(jogadores, QuantidadeDeBaralho());
                partida.IniciarPartida();   
                ExibirHistoricoJogador();
                Console.WriteLine("\nDeseja iniciar uma nova partida? - s / n");
                resp = char.Parse(Console.ReadLine());
            }
        }

        static void ExibirHistoricoJogador()
        {
            char resp = 's';
            string nome = "";
            Console.WriteLine("\nDeseja visualizar o histórico de algum jogador em específico? - s / n");
            resp = char.Parse(Console.ReadLine());
            if(resp == 's')
            {
                Console.WriteLine($"Digite o nome do jogador que deseja pesquisar:");
                nome = Console.ReadLine();
            }
            for(int i = 0; i < jogadores.Length; i++)
            {
                if(jogadores[i].Nome == nome)
                {
                    Console.WriteLine($"Rank do {jogadores[i].Nome}\n{jogadores[i].ExibirRank()}");
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
                    Esperar(tempoDeEsperar, mensagemErro);
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
                        Esperar(tempoDeEsperar, mensagemErro);
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
                    Esperar(tempoDeEsperar, mensagemErro);
                }

            } while (numDeBaralho < 1);

            return new MonteDoJogo(numDeBaralho);
        }

        static void Cabecalho()
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine($"===========================================");

            Console.Write("            ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("♣");
            Console.ResetColor();

            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♥");
            Console.ResetColor();

            Console.Write(" Rouba monte ");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("♠");
            Console.ResetColor();

            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♦");
            Console.ResetColor();

            Console.WriteLine("            ");

            Console.WriteLine($"===========================================\n\n\n\n\n");
        }

        static void Esperar(int milissegundos, string mensagem)
        {
            int tempoPassou = 0;

            Cabecalho();
            Console.WriteLine($"{mensagem}\n");
            Console.WriteLine("Aguarde 5 segundos ou aperte ENTER para começar...");
            while (tempoPassou < milissegundos)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    tempoPassou = milissegundos;
                }
                else
                {
                    Thread.Sleep(100);
                    tempoPassou += 100;
                }
            }
        }


    }
}
