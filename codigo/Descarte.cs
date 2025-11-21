using System;
using System.Collections.Generic;

namespace Rouba_Monte
{
    internal class Descarte
    {
        #region Variáveis
        private List<Carta> _cartas;
        #endregion

        #region Construtores
        /// <summary>
        /// Inicialmente, o descarte começa vazio
        /// </summary>
        public Descarte()
        {
            _cartas = new List<Carta>();
        }
        #endregion
        
        #region Métodos
        /// <summary>
        /// Recebe o descarte de um jogador e coloca no Descarte da Partida
        /// </summary>
        /// <param name="carta"></param>
        public void ReceberDescarte(Carta carta)
        {
            _cartas.Add(carta);
        }
        
        /// <summary>
        /// Pega a carta do descarte caso a carta da vez caso seja igual a alguma carta do monte, 
        /// caso não seja retorna null
        /// </summary>
        /// <param name="cartaDaVez"></param>
        /// <returns>carta do Descarte || null</returns>
        public Carta? PegarCarta(Carta cartaDaVez)
        {
            for(int i = 0; i < _cartas.Count; i++)
            {
                if(cartaDaVez.Valor == _cartas[i].Valor)
                {
                    Carta cartaEncontrada = _cartas[i];
                    _cartas.RemoveAt(i);
                    return cartaEncontrada;
                }
            }
            return null;
        }
        #endregion
    } 
}