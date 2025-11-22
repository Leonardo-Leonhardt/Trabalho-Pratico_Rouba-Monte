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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var carta in _cartas)
            {
                sb.Append($"{carta.ToString()}\n");
            }

            sb.AppendLine($"Numeros de cartas: {_cartas.Count()}");

            return sb.ToString();
        }
    }
}
