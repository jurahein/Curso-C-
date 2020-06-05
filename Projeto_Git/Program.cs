using System;

namespace Projeto_Git
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teste Git!");
            Console.WriteLine("Quantos 'oi' você quer que apareça ? ");
            
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("-------------------");
            for (int i = 0; i < p; i++)
            {
                Console.WriteLine(i+1 + ") --> " + " oi");
            }
        }
    }
}
