namespace Rouba_Monte
{
    internal class Program
    {
        static Jogador[] jogadores = MenuJogador();

        static Jogador[] MenuJogador()
        {
            Console.WriteLine("Digite a quantidade de jogadores");
            int qtdeJogadores = int.Parse(Console.ReadLine());
            Jogador[] jogadores = new Jogador[qtdeJogadores];
            int i = 0;
            while(i < qtdeJogadores)
            {
                Console.WriteLine($"Digite o nome do {i+1} player");
                jogadores[i] = new Jogador(Console.ReadLine());
                i++;
            }
            return jogadores;
        }
        
        static void Main(string[] args)
        {
            char resp = 's';
            Partida partida;
            while(resp != 'n')
            {
                partida = new Partida(jogadores);
                partida.IniciarPartida();

                MenuHistorico();

                Console.WriteLine("Deseja iniciar uma nova partida?");
                resp = char.Parse(Console.ReadLine());
            }
        }

        static void MenuHistorico()
        {
            Console.WriteLine("Deseja visualizar o histórico de algum jogador?");
            char resp = char.Parse(Console.ReadLine());
            switch (resp)
            {
                case 'n':
                break;
                case 's':
                    Console.WriteLine("Digite o nome dele");
                    VisualizarHistorico(Console.ReadLine());
                break;
                default:
                break;
            }
        }

        static void VisualizarHistorico(string nome)
        {

        }
    }
}
