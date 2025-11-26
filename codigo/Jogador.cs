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
        public Jogador(string? nome)
        {
            _nome = nome;
            _posicao = 0;
            _monte = new MonteDoJogador();
            _ranking = new Queue<int>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Rouba o monte do outro jogador e o coloca acima do seu
        /// </summary>
        /// <param name="outro"></param>
        /// <returns>booleano para a condição descrita</returns>
        public void RoubarMonte(Carta cartaDaVez, Jogador jogador)
        {
            _monte.AddCarta(jogador.Monte.PegarBaralho());
            _monte.AddCarta(cartaDaVez);
        }

        /// <summary>
        /// Verifica se a carta da vez é igual ao monte de outro jogador
        /// </summary>
        /// <param name="cartaDaVez"></param>
        /// <param name="jogador"></param>
        /// <returns>verdadeiro caso seja, falso caso contrário</returns>
        public bool PodeRoubar(Carta cartaDaVez, Jogador jogador)
        {
            try
            {
                if(cartaDaVez.Valor == jogador.Monte.VerUtimaCarta().Valor)
                    return true;
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return false;
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
                Console.WriteLine(ex.Message);
                return false;
            }
            return false;
        }
        

        /// <summary>
        /// Adiciona a carta do descarte e a carta da vez ao monte do jogador
        /// </summary>
        /// <param name="cartaDescarte"></param>
        /// <param name="cartaDaVez"></param>
        public void PegarDescarte(Carta cartaDescarte, Carta cartaDaVez)
        {
            _monte.AddCarta(cartaDescarte);
            _monte.AddCarta(cartaDaVez);
        }

        /// <summary>
        /// Método para Comprar a Carta da Vez
        /// </summary>
        /// <param name="carta"></param>
        /// <returns>carta da vez ou nulo se o Monte do Jogo estiver vazio</returns>
        public Carta? ComprarCarta(MonteDoJogo monteDeCompras)
        {
            return monteDeCompras.ComprarCarta();   
        }

        /// <summary>
        /// Calcula a pontuação do jogador com base no valor de cartas em seu monte.
        /// </summary>
        /// <returns>Pontuação atual do jogador</returns>
        public int VerificarPontuacao()
        {
            return _monte.Cartas.Count;
        }

        /// <summary>
        /// Função para atualizar o ranking do jogador com no máximo 5 resultados salvos.
        /// </summary>
        /// <param name="posicao"></param>
        public void AtualizarRank(int posicao)
        {
            _posicao = posicao;
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

        public override string ToString()
        {
            return $"Posição: {_posicao}º | Nome: {_nome}";
        }
        #endregion

        #region Getters e Setters
        public MonteDoJogador Monte
        {
            get { return _monte; }
        }
        #endregion
    }
}