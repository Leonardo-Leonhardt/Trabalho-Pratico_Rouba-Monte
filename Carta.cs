using System;
using System.Text;

namespace Rouba_Monte
{
    public class Carta
    {
        private int _valor;
        private string _naipe;

        public Carta(int numero, string naipe)
        {
            if (!ValidarNaipe(naipe))
            {
                throw new ArgumentException($"O naipe '{naipe}' é inválido. Naipes válidos são: copas, espadas, ouros ou paus.");
            }

            if (!ValidarNumero(numero))
            {
                throw new ArgumentException($"O valor '{numero}' para a carta é inválido. O número deve ser entre 1 (Ás) e 13 (Rei).");
            }

            this._valor = numero;
            this._naipe = naipe;
        }

        private bool ValidarNaipe(string naipe)
        {
            if (naipe == "copas" || naipe == "espadas" || naipe == "ouros" || naipe == "paus")
            {
                return true;
            }

            return false;
        }

        private bool ValidarNumero(int numero)
        {
            if (numero < 1 || numero > 13)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Carta");
            sb.AppendLine($"Numero: {_valor}");
            sb.AppendLine($"Naipe: {_naipe}");

            return sb.ToString();
        }
    }
}