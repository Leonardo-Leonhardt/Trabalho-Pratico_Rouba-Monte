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

            _numDeCartasNoMonte++;
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
                _numDeCartasNoMonte++;
                _cartas.Push(carta);
            }

            return true;
        }
        public Stack<Carta> PegarBaralho()
        {
            Stack<Carta> baralho = _cartas;

            _cartas.Clear();

            return baralho;
        }

        public Carta VerUtimaCarta()
        {
            return _cartas.Peek();
        }
    }
}
