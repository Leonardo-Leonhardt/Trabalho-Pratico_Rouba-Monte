using System;
using System.Collections.Generic;
using System.Text;

namespace Rouba_Monte
{
    internal class Partida
    {
        private MonteDoJogo _monteDoJogo;
        private Descarte _descarte;
        private Jogador[] _jogadores;
        private int _rodada;
        private Jogador[] _ranking;

        public Partida(Jogador[] jogadores, MonteDoJogo monteDoJogo)
        {
            this._monteDoJogo = monteDoJogo;
            this._descarte = new Descarte();
            this._jogadores = jogadores;
            this._rodada = 0;
        }

        public void IniciarPartida()
        {
            while (_monteDoJogo.QuantCartaTem > 0)
            {
                Console.ReadKey();
                IniciarNovaRodada();
            }


            FinalizarPartida();
        }

        private void IniciarNovaRodada()
        {
            _rodada++;
            Console.WriteLine($"Iniciando a Rodada {_rodada}");
            foreach (Jogador jogador in _jogadores) //Não linear ainda
            {
                NovaJogada(jogador, _monteDoJogo, _descarte);
            }
        }

        //O método está recursivo para fins de teste, não sei se tem que trocar para linear (ou se assim já está considerado linear)
        private void NovaJogada(Jogador jogador, MonteDoJogo _monteDoJogo, Descarte _descarte)
        {
            Carta cartaDaVez = jogador.ComprarCarta(_monteDoJogo);
            if (cartaDaVez is null)
                return;

            Console.WriteLine(cartaDaVez); //usa o método ToString implicitamente, alterar para o formato de arquivo pedido no trab

            if (TentarRoubarMontes(jogador, cartaDaVez) || TentarPegarDescarte(jogador, _descarte, cartaDaVez) || TentarColocarNoMonte(jogador, cartaDaVez) || TentarColocarNoMonte(jogador, cartaDaVez))
            {
                NovaJogada(jogador, _monteDoJogo, _descarte);

            }
            else
            {
                _descarte.ReceberDescarte(cartaDaVez);
            }
        }


        private bool TentarRoubarMontes(Jogador jogador, Carta cartaDaVez)
        {
            bool conseguiuRoubar = false;
            Jogador jogadorRoubado = new Jogador(null);

            // logica tem que mudar eu tenho que compara com todos primeiro e ver quais jogadores tem acarta específica
            // ai eu salvo a posicao dele/s se for mais de um ai compata para ver que tem mais carta, se tive o mesmo numero
            // pega o mente aleatoriamente

            // do jeito que tar ele vai compara um por um e se tivar mais de 1 ele vai pegar de todos

            foreach (Jogador jogadorComparado in _jogadores)
            {
                if (jogador != jogadorComparado) // talvel com a fila circula fique melhor
                {
                    if (jogador.PodeRoubar(cartaDaVez, jogadorComparado))
                    {
                        if (jogadorRoubado.Monte.QuantCartaTem > jogadorComparado.Monte.QuantCartaTem)
                        {
                            jogadorRoubado = jogadorComparado;
                        }
                        else if (jogadorRoubado.Monte.QuantCartaTem == jogadorComparado.Monte.QuantCartaTem)
                        {
                            Random jogadorAleatorio = new Random();
                            if (jogadorAleatorio.Next(1) == 1)
                                jogadorRoubado = jogadorComparado;
                        }
                        conseguiuRoubar = true;
                    }
                }
            }
            if (conseguiuRoubar)
                jogador.RoubarMonte(cartaDaVez, jogadorRoubado);
            return conseguiuRoubar;
        }

        private bool TentarPegarDescarte(Jogador jogador, Descarte _descarte, Carta cartaDaVez)
        {
            Carta cartaDescarte = _descarte.PegarCarta(cartaDaVez);
            if (cartaDescarte is not null)
            {
                jogador.PegarDescarte(cartaDescarte, cartaDaVez);
                return true;
            }
            return false;
        }

        private bool TentarColocarNoMonte(Jogador jogador, Carta cartaDaVez)
        {
            if (jogador.CompararCartas(cartaDaVez))
            {
                jogador.Monte.AddCarta(cartaDaVez);
                return true;
            }
            return false;
        }

        private void FinalizarPartida()
        {
            DefinirRanking(); //o jogador que tiver mais cartas ganha a partida, em caso de empate todos ganham
            ExibirVencedores(); //nome, posição e cartas no monte
            //ExibirRanking(); //ordenado por cartas no monte de cada jogador
        }

        private void DefinirRanking()
        {

        }

        private void ExibirVencedores()
        {
            Console.ReadKey();
            int pontuacaoMax = _ranking[0].Monte.QuantCartaTem;
            foreach (Jogador jogador in _ranking)
            {
                if (jogador.Monte.QuantCartaTem >= pontuacaoMax)
                    Console.WriteLine($"{jogador}, você é um(a) Vencedor(a)!!");
            }
        }
    }
}