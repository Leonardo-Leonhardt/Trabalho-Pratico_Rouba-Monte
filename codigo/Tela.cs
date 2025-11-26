using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rouba_Monte
{
    public static class Tela
    {
        public static void Cabecalho()
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine($"===========================================");

            Console.Write("            ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("♣");
            Console.ResetColor();

            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♥");
            Console.ResetColor();

            Console.Write(" Rouba monte ");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("♠");
            Console.ResetColor();

            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♦");
            Console.ResetColor();

            Console.WriteLine("            ");

            Console.WriteLine($"===========================================\n\n\n\n\n");
        }
    }
}
