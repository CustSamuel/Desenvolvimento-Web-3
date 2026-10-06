using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int somaImpares = lista.Where(n => n % 2 != 0).Sum();

            Console.WriteLine("--- Exercício 1 ---");
            Console.WriteLine($"Soma dos ímpares: {somaImpares}");
        }
    }
}