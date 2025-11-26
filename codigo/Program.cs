using System.Text;

namespace Rouba_Monte
{
    internal class Program
    {
        static Jogador[] jogadores;
        static MonteDoJogo monteDoJogo;

        static int tempoDeEsperar = 5000;

        static void Main()
        {
            Cabecalho();

            QuantidadeDeJogador();
            QuantidadeDeBaralho();












            Cabecalho();
            Console.WriteLine($"\nCatas: {monteDoJogo.QuantCartaTem}");
            Console.WriteLine($"\nJogadores: ");
            foreach (Jogador jogador in jogadores)
            {
                Console.WriteLine($"{jogador.ToString()}");
            }


            Console.ReadKey();
        }

        static void StartTheGame()
        {

        }
        static void QuantidadeDeJogador()
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

        static void QuantidadeDeBaralho()
        {
            int numDeBaralho;
            string mensagemErro = "Número de Baralho insuficiente!!!";

            do
            {
                Cabecalho();

                Console.WriteLine($"Quantos Baralho vão ter o jogo?");
                numDeBaralho = Convert.ToInt32(Console.ReadLine());

                if (numDeBaralho < 1)
                {
                    Esperar(tempoDeEsperar, mensagemErro);
                }

            } while (numDeBaralho < 1);

            monteDoJogo = new MonteDoJogo(numDeBaralho);
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
