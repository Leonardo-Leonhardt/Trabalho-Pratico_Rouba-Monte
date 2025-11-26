using System;
using System.Collections.Generic;
using System.Text;

namespace Rouba_Monte
{
    class Insercao
    {
        private Jogador[] _array;
        private int _tamanho;

        public Insercao(Jogador[] array)
        {
            _array = array;
            _tamanho = array.Length;
        }

        public void Ordenar()
        {
            for (int i = 1; i < _tamanho; i++) {
                
                int qtdeCartas = _array[i].Monte.QuantCartaTem;
                Jogador objTmp = _array[i];
                
                int j = i - 1;
                
                while ((j >= 0) && (_array[j].Monte.QuantCartaTem > qtdeCartas))
                {
                    _array[j + 1] = _array[j];
                    j--;
                }
                _array[j + 1] = objTmp;
            }
        }

        public override string ToString()
        {
            StringBuilder vetorString = new StringBuilder();
            for (int i = 0; i < _array.Length; i++)
            {
                vetorString.Append($"{i} - {_array[i]} ");
            }
            return vetorString.ToString();
        }
    }
}