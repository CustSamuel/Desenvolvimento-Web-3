using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio3
{
    class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = "João", Idade = 17 },
                new Pessoa { Nome = "Maria", Idade = 22 },
                new Pessoa { Nome = "Carlos", Idade = 30 }
            };

            var maioresDe18 = pessoas.Where(p => p.Idade > 18).ToList();
            var nomesOrdenados = pessoas.OrderBy(p => p.Nome).Select(p => p.Nome).ToList();

            Console.WriteLine("--- Exercício 3 ---");
            Console.WriteLine("Maiores de 18:");
            maioresDe18.ForEach(p => Console.WriteLine($"- {p.Nome}"));

            Console.WriteLine("\nNomes ordenados alfabeticamente:");
            nomesOrdenados.ForEach(nome => Console.WriteLine($"- {nome}"));
        }
    }
}