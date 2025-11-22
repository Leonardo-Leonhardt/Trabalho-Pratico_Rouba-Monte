using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rouba_Monte
{
    // ja testado
    internal class MonteDoJogo : Monte
    {
        private string[] _naipe = new string[] { "copas", "espadas", "ouros", "paus" };
        private List<Carta> cartas = new List<Carta>();
        private int _tamanhoBaralho = 52;
        private int _numDeCartas = 13;

        public bool GerarMonte(int numDeBaralhos)
        {
            if (numDeBaralhos < 1)
            {
                return false;
            }

            GerarBaralho(numDeBaralhos);

            EmbaranhaMonte();

            return true;

        }

        private bool GerarBaralho(int numDeBaralhos)
        {

            int cartasDeNaipes = (numDeBaralhos * _tamanhoBaralho) / _naipe.Length;

            for (int i = 0; i < _naipe.Length; i++)
            {
                for (int x = 0; x < cartasDeNaipes / 13; x++)
                {
                    for (int j = 0; j < _numDeCartas; j++)
                    {
                        cartas.Add(new Carta(j + 1, _naipe[i]));
                    }
                }
            }

            return true;
        }

        private bool EmbaranhaMonte()
        {
            Random random = new Random();
            int valor = cartas.Count;

            while (valor > 1)
            {
                valor--;
                int indece = random.Next(valor + 1);

                Carta carta = cartas[indece];
                cartas[indece] = cartas[valor];
                cartas[valor] = carta;
            }

            foreach (Carta cart in cartas)
            {
                _cartas.Push(cart);
            }

            cartas.Clear();
            return true;
        }

        public Carta? ComprarCarta()
        {
            if (!ValidarMonta())
            {
                return null;
            }

            return _cartas.Pop();
        }

        private bool ValidarMonta()
        {
            if (_cartas.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
