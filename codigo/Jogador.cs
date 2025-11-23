using System;
using System.Collections.Generic;
using System.Text;

namespace Rouba_Monte
{
    internal class Jogador
    {
        private string _nome;
        private int _posicao;
        private MonteDoJogador _monte;
        private Queue<int> _ranking;

        public Jogador(string nome)
        {
            _nome = nome;
            _posicao = 0;
            _monte = new MonteDoJogador();
            _ranking = new Queue<int>();
        }

        /// <summary>
        /// Rouba o monte do outro jogador se o valor da carta acima do seu monte for igual ao dele. 
        /// </summary>
        /// <param name="outro"></param>
        /// <returns>booleano para a condição descrita</returns>
        public bool RoubarMonte(MonteDoJogador outro)
        {
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
        /// <returns>carta da vez ou nulo se o monte estiver vazio</returns>
        public Carta? ComprarCarta(Carta? carta)
        {
            if (carta is not null)
            {
                _monte.Push(carta);
                return _monte.Peek();   
            }
            return null;
        }

        public int VerificarPontuacao()
        {
            
        }

        public void AtualizarRank()
        {
            
        }

        public string ExibirRank()
        {
            StringBuilder rankAtualizado = new StringBuilder();
            int i = 0;
            foreach(int rank in _ranking)
            {
                i++;
                rankAtualizado.appendLine($"{i} - {rank}");
            }
            return rankAtualizado.ToString();
        }
    }
}