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

            while(resp != "n")
            {
                NovaPartida();
                Console.WriteLine("Deseja iniciar uma nova partida?");
                resp = Console.ReadLine();
            }
        }

        static void NovaPartida()
        {
            Console.WriteLine("Com quantos baralhos vocês jogarão?");
            
            Monte monteDoJogo = new MonteDoJogo(int.Parse(Console.ReadLine()));
            Descarte descarte = new Descarte();

            foreach(Jogador jogador in jogadores) //Não linear ainda
            {
                while(NovaJogada(jogador, monteDoJogo, descarte));
            }
        }

        static bool NovaJogada(Jogador jogador, Monte monteDoJogo, Descarte descarte)
        {
            Carta cartaDaVez = jogador.ComprarCarta(monteDoJogo);
            if(!TentarRoubarMontes(jogador, cartaDaVez))
                descarte.ReceberDescarte(cartaDaVez);
        }

        static bool TentarRoubarMontes(Jogador jogador, Carta cartaDaVez)
        {
            var conseguiuRoubar = false;
            List<Jogador> jogadoresRoubaveis = new List<Jogador>();

            foreach(Jogador jogadorComparado in jogadores) //Não linear ainda
            {
                if(jogador != jogadorComparado)
                {    
                    if (jogador.RoubarMonte(cartaDaVez, jogadorComparado))
                    {
                        conseguiuRoubar = true;
                    }
                }
            }
            return conseguiuRoubar;
        }
    }
}
