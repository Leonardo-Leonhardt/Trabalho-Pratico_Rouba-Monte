using System;
using System.Collections.Generic;
using System.Text;

namespace Rouba_Monte
{
    internal class Jogador
    {
        #region Variáveis
        private string _nome;
        private int _posicao;
        private MonteDoJogador _monte;
        private Queue<(int NumPartida, int Posicao)> _ranking;
        #endregion

        #region Construtores
        public Jogador(string? nome)
        {
            _nome = nome;
            _posicao = 0;
            _monte = new MonteDoJogador();
            _ranking = new Queue<(int, int)>();
        }
        #endregion

        #region Métodos
        public void RoubarMonte(Carta cartaDaVez, Jogador jogador)
        {
            _monte.AddCarta(jogador.Monte.PegarBaralho());
            _monte.AddCarta(cartaDaVez);
        }

        public bool PodeRoubar(Carta cartaDaVez, Jogador jogador)
        {
            try
            {
                return cartaDaVez.Valor == jogador.Monte.VerUtimaCarta().Valor;
            }
            catch(InvalidOperationException ex)
            {
                return false;
            }
        }

        public bool CompararCartas(Carta outra)
        {
            try
            {
                if(outra.Valor == _monte.VerUtimaCarta().Valor)
                    return true;
            }
            
            catch(InvalidOperationException ex)
            {
                return false;
            }
            return false;
        }
        
        public void PegarDescarte(Carta cartaDescarte, Carta cartaDaVez)
        {
            _monte.AddCarta(cartaDescarte);
            _monte.AddCarta(cartaDaVez);
        }

        public Carta? ComprarCarta(MonteDoJogo monteDeCompras)
        {
            return monteDeCompras.ComprarCarta();   
        }

        public int VerificarPontuacao()
        {
            return _monte.Cartas.Count;
        }

        public void AtualizarRank(int partida, int posicao)
        {
            var resultadoPartida = (NumPartida: partida, Posicao: posicao);
            _posicao = posicao;
            _ranking.Enqueue(resultadoPartida);
            if(_ranking.Count > 5) 
                _ranking.Dequeue();
        }

        public string ExibirRank()
        {
            StringBuilder rankAtualizado = new StringBuilder();
            
            foreach(var resultado in _ranking){
                rankAtualizado.AppendLine($"Partida {resultado.NumPartida}: {resultado.Posicao}° Lugar");
            }
            return rankAtualizado.ToString();
        }

        public void ResetarDados()
        {
            _posicao = 0;
            _monte = new MonteDoJogador();
        }
        public override string ToString()
        {
            return $"Posição: {_posicao}º | Nome: {_nome} - Cartas no monte: {_monte.QuantCartaTem}";
        }
        #endregion

        #region Getters e Setters
        public MonteDoJogador Monte
        {
            get { return _monte; }
        }
        public string Nome
        {
            get { return _nome; }
        }
        #endregion
    }
}