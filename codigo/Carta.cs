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

            switch (_valor)
            {
                case 1:
                    sb.Append($"Ás (A)");
                break;
                case 2:
                    sb.Append($"Dois (2)");
                break;
                case 3:
                    sb.Append($"Três (3)");
                break;
                case 4:
                    sb.Append($"Quatro (4)");
                break;
                case 5:
                    sb.Append($"Cinco (5)");
                break;
                case 6:
                    sb.Append($"Seis (6)");
                break;
                case 7:
                    sb.Append($"Sete (7)");
                break;
                case 8:
                    sb.Append($"Oito (8)");
                break;
                case 9:
                    sb.Append($"Nove (9)");
                break;
                case 10:
                    sb.Append($"Dez (10)");
                break;
                case 11:
                    sb.Append($"Valete (J)");
                break;
                case 12:
                    sb.Append($"Dama (Q)");
                break;
                case 13:
                    sb.Append($"Rei (K)");
                break;
                default:
                    sb.Append($"Numero: ({_valor})");
                break;
            }
            sb.Append($" - Naipe: {_naipe}");

            return sb.ToString();
        }

         public int Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
    }
}