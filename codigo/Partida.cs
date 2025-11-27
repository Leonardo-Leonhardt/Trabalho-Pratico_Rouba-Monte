using System;
using System.Collections.Generic;
using System.Text;
using static Rouba_Monte.Tela;
using static Rouba_Monte.Parada;
using static Rouba_Monte.Arquivo;

namespace Rouba_Monte
{
    internal class Partida
    {
        private static int _numPartida = 0;
        private MonteDoJogo _monteDoJogo;
        private Descarte _descarte;
        private Jogador[] _jogadores;
        private int _rodada;
        private Insercao _ranking;

        public Partida(Jogador[] jogadores, MonteDoJogo monteDoJogo)
        {
            _numPartida++;
            _monteDoJogo = monteDoJogo;
            _descarte = new Descarte();
            _jogadores = jogadores;
            _rodada = 0;
        }

        public void IniciarPartida()
        {
            Cabecalho();
            Console.WriteLine($"Monte do jogo criado com {_monteDoJogo.QuantCartaTem} cartas\n");
            ResetarDadoJogadores();

            while (_monteDoJogo.QuantCartaTem > 0)
            {
                //Console.ReadKey();
                Cabecalho();
                IniciarNovaRodada();
            }


            FinalizarPartida();
        }

        private void ResetarDadoJogadores()
        {
            foreach (Jogador jogador in _jogadores)
            {
                jogador.ResetarDados();
            }
        }

        private void IniciarNovaRodada()
        {
            _rodada++;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\n\nIniciando a Rodada {_rodada}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nNº de cartas: {_monteDoJogo.QuantCartaTem}");
            Console.ResetColor();

            try
            {
                foreach (Jogador jogador in _jogadores)
                {
                    NovaJogada(jogador, _monteDoJogo, _descarte);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\n{ex.Message}, Finalizando a partida...");
                Console.ResetColor();
            }
        }

        private void NovaJogada(Jogador jogador, MonteDoJogo _monteDoJogo, Descarte _descarte)
        {
            Console.WriteLine($"\n\nNova Jogada - {jogador.Nome}");
            Carta cartaDaVez = jogador.ComprarCarta(_monteDoJogo);
            if (cartaDaVez is null)
                throw new InvalidOperationException("O monte do jogo está vazio");

            Console.WriteLine($"Carta da vez: {cartaDaVez}"); //usa o método ToString implicitamente, alterar para o formato de arquivo pedido no trab

            if (TentarRoubarMontes(jogador, cartaDaVez) || TentarPegarDescarte(jogador, _descarte, cartaDaVez) || TentarColocarNoMonte(jogador, cartaDaVez) || TentarColocarNoMonte(jogador, cartaDaVez))
                NovaJogada(jogador, _monteDoJogo, _descarte);
            else
            {
                Console.Write($"A vez de {jogador.Nome} foi finalizada. O descarte recebe a carta da vez");
                _descarte.ReceberDescarte(cartaDaVez);
                Console.Write($"\nDescarte{_descarte}");
            }
        }

        private bool TentarRoubarMontes(Jogador jogador, Carta cartaDaVez)
        {
            List<Jogador> jogadoresRoubaveis = new List<Jogador>();
            Jogador jogadorRoubado = new Jogador(null);
            bool conseguiuRoubar = false;
            int maiorMonte = 0;

            foreach (Jogador jogadorComparado in _jogadores)
            {
                if (jogadorComparado != jogador && jogador.PodeRoubar(cartaDaVez, jogadorComparado))
                {
                    if (jogadorComparado.Monte.QuantCartaTem > maiorMonte)
                    {
                        maiorMonte = jogadorComparado.Monte.QuantCartaTem;
                        jogadorRoubado = jogadorComparado;
                        jogadoresRoubaveis.Clear();
                        jogadoresRoubaveis.Add(jogadorComparado);
                    }
                    else if (jogadorComparado.Monte.QuantCartaTem == maiorMonte)
                        jogadoresRoubaveis.Add(jogadorComparado);

                    conseguiuRoubar = true;
                }
            }
            if (jogadoresRoubaveis.Count > 1)
            {
                Console.WriteLine("Houve um empate, escolhendo aleatoriamente um dos jogadores com maior monte para ser roubado...");
                Random jogadorAleatorio = new Random();
                jogadorRoubado = jogadoresRoubaveis[jogadorAleatorio.Next(jogadoresRoubaveis.Count)];
            }

            if (conseguiuRoubar)
            {
                Console.Write($"{jogadorRoubado.Nome} teve seu monte com {jogadorRoubado.Monte.QuantCartaTem} cartas roubado por {jogador.Nome}. A carta do topo de seu monte era {jogadorRoubado.Monte.VerUtimaCarta()}");
                jogador.RoubarMonte(cartaDaVez, jogadorRoubado);
            }
            return conseguiuRoubar;
        }

        private bool TentarPegarDescarte(Jogador jogador, Descarte _descarte, Carta cartaDaVez)
        {
            Carta cartaDescarte = _descarte.PegarCarta(cartaDaVez);
            if (cartaDescarte is not null)
            {
                Console.Write($"{jogador.Nome} pegou a carta {cartaDescarte} do descarte");
                jogador.PegarDescarte(cartaDescarte, cartaDaVez);
                return true;
            }
            return false;
        }

        private bool TentarColocarNoMonte(Jogador jogador, Carta cartaDaVez)
        {
            if (jogador.CompararCartas(cartaDaVez))
            {
                Console.Write($"{jogador.Nome} colocou a carta da vez no seu monte");
                jogador.Monte.AddCarta(cartaDaVez);
                return true;
            }
            return false;
        }

        private void FinalizarPartida()
        {
            Cabecalho();
            DefinirRanking(); //o jogador que tiver mais cartas ganha a partida, em caso de empate todos ganham
            ExibirVencedores(); //nome, posição e cartas no monte
            ExibirRanking(); //ordenado por cartas no monte de cada jogador

            Console.WriteLine($"\n\n==> {_descarte.ToString()}"); //so um teste
            Esperar();
        }

        private void DefinirRanking()
        {
            _ranking = new Insercao(_jogadores);
            _ranking.Ordenar();
            _ranking.AtualizarRank(_numPartida);
        }

        private void ExibirVencedores()
        {

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n\nVencedores da partida");
            Console.ResetColor();

            int pontuacaoMax = _ranking.Array[0].Monte.QuantCartaTem;
            foreach (Jogador jogador in _jogadores)
            {
                if (jogador.Monte.QuantCartaTem >= pontuacaoMax)
                    Console.WriteLine($"{jogador}, você é um(a) Vencedor(a)!!");
            }
        }
        private void ExibirRanking()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nRanking Final");
            Console.ResetColor();
            Console.Write(_ranking);
        }
    }
}