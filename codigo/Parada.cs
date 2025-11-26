using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rouba_Monte.Tela;

namespace Rouba_Monte
{
    public static class Parada
    {
                static int milissegundos = 5000;

        public static void Esperar(string mensagem)
        {
            int tempoPassou = 0;

            Cabecalho();
            Console.WriteLine($"{mensagem}\n");
            Console.WriteLine("Aguarde 5 segundos ou aperte ENTER para começar...");
            while (tempoPassou < milissegundos)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    tempoPassou = milissegundos;
                }
                else
                {
                    Thread.Sleep(100);
                    tempoPassou += 100;
                }
            }
        }
    }
}
