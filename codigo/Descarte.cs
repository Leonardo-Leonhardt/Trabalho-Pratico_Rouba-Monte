using System;
using System.Collections.Generic;
using System.Text;

namespace Rouba_Monte
{
    internal class Descarte
    {
        #region Variáveis
        private List<Carta> _cartas;
        #endregion

        #region Construtores
        public Descarte()
        {
            _cartas = new List<Carta>();
        }
        #endregion
        
        #region Métodos
        public void ReceberDescarte(Carta carta)
        {
            _cartas.Add(carta);
        }
        
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
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Carta carta in _cartas)
            {
                sb.Append($" | {carta}");
            }
            return sb.ToString();
        }
        #endregion
    } 
}