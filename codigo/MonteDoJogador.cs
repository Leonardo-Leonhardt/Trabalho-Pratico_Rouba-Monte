using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rouba_Monte
{
    // falta testa
    internal class MonteDoJogador : Monte
    {
        public bool AddCarta(Carta carta)
        {
            if (carta == null)
            {
                return false;
            }

            _cartas.Push(carta);
            return true;
        }

        public bool AddCarta(Stack<Carta> cartas)
        {
            if (cartas.Count == 0)
            {
                return false;
            }

            foreach (Carta carta in cartas)
            {
                _cartas.Push(carta);
            }

            return true;
        }

        public Carta VerUtimaCarta()
        {
            return _cartas.Pop();
        }
    }
}
