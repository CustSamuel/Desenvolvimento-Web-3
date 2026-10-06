using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int> { 5, 12, 8, 20, 3, 15, 7 };

            int maiorNumero = numeros.Max();

            int somaMaioresQue10 = numeros.Where(n => n > 10).Sum();

            Console.WriteLine("--- Exercício 2 ---");
            Console.WriteLine($"Maior número: {maiorNumero}");
            Console.WriteLine($"Soma dos maiores que 10: {somaMaioresQue10}");
        }
    }
}