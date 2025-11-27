using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rouba_Monte
{
    internal class Arquivo
    {

        private static string caminho = @"Log_partidas.txt";
        private static string titulo = "Log do Rouba-Monte";


        public static bool CriarArquivo()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(caminho, false))
                {

                    sw.WriteLine($"{titulo}\n\n");


                }
            }
            catch (Exception e)
            {

            }

            return false;
        }

        public static bool AbrirArquivo()
        {







            return false;
        }

        public static bool FechaArquivo()
        {
            return false;
        }

        public static string SalvaDados(string log)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(caminho, true))
                {

                    sw.WriteLine($"{log}");










                }

            }
            catch (Exception e)
            {

            }


            return log;
        }


    }
}
