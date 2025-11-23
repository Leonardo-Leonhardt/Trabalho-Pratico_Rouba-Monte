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
        private Queue<int> _ranking;
        #endregion

        #region Construtores
        public Jogador(string nome)
        {
            _nome = nome;
            _posicao = 0;
            _monte = new MonteDoJogador();
            _ranking = new Queue<int>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Rouba o monte do outro jogador se o valor da carta acima do seu monte for igual ao dele. 
        /// </summary>
        /// <param name="outro"></param>
        /// <returns>booleano para a condição descrita</returns>
        public bool RoubarMonte(MonteDoJogador outro)
        {
            // seria da carta da vem em vez do monte 
            // tem um metodo que retorna o monte do jogador e apaga ele 
            if(_monte.VerUtimaCarta().Valor == outro.VerUtimaCarta().Valor)
            {
                _monte.AddCarta(outro);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método para Comprar a Carta da Vez
        /// </summary>
        /// <param name="carta"></param>
        /// <returns>carta da vez ou nulo se o Monte do Jogo estiver vazio</returns>
        public Carta? ComprarCarta(Carta? carta)
        {
            if (carta is not null)
            {
                _monte.Push(carta);
                return _monte.Peek();   
            }
            return null;
        }

        /// <summary>
        /// Calcula a pontuação do jogador com base no valor de cada carta em seu monte.
        /// </summary>
        /// <returns>Pontuação atual do jogador</returns>
        public int VerificarPontuacao()
        {
            // acho que a pontuação e qualculada com base no numero de cartas nao no valor delas
            int pontuacao = 0;
            foreach(Carta carta in _monte.Carta)
            {
                pontuacao += carta.Valor;
            }
            return pontuacao;
        }

        /// <summary>
        /// Função para atualizar o ranking do jogador com no máximo 5 resultados salvos.
        /// </summary>
        public void AtualizarRank()
        {
            _ranking.Enqueue(_posicao);
            if(_ranking.Count > 5) 
                _ranking.Dequeue();
        }

        /// <summary>
        /// Método para exibir toda a lista de rank
        /// </summary>
        /// <returns>rank das ultimas 5 partidas</returns>
        public string ExibirRank()
        {
            StringBuilder rankAtualizado = new StringBuilder();
            int i = 0;
            foreach(int rank in _ranking)
            {
                i++;
                rankAtualizado.AppendLine($"{i} - {rank}");
            }
            return rankAtualizado.ToString();
        }
        #endregion
    }
}