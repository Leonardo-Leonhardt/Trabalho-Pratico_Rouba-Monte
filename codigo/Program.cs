namespace Rouba_Monte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MonteDoJogo jogo = new MonteDoJogo();

            Console.WriteLine($"Carta comprada:\n {jogo.ComprarCarta()}");

            Console.ReadKey();

            if (!jogo.GerarMonte(2))
            {
                Console.WriteLine($"Numero de baralhos inferior a 1");
            }
            else
            {
                Console.WriteLine(jogo.ToString());
                Console.WriteLine("-->" + jogo.QuantCartaTem);

            }

            Console.ReadKey();

            for (int x = 0; x < 7; x++)
            Console.WriteLine($"Carta comprada: \n{jogo.ComprarCarta()}");

            Console.ReadKey();

            Console.WriteLine(jogo.ToString());
        }
    }
}
