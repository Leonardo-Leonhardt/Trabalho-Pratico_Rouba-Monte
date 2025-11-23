using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rouba_Monte
{
    internal class Monte
    {
        protected Stack<Carta> _cartas = new Stack<Carta>();
        protected int _numDeCartasNoMonte;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var carta in _cartas)
            {
                sb.Append($"{carta.ToString()}\n");
            }

            return sb.ToString();
        }

        public Stack<Carta> Cartas
        {
            get { return _cartas; }
        }

        public int QuantCartaTem
        {
            get { return _numDeCartasNoMonte; }
        }
    }
}
