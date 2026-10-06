using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio4
{
    class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }

    class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }

    class Pedido
    {
        public int Quantidade { get; set; }
        public DateTime DataPedido { get; set; }
        public Produto Produto { get; set; }
        public Cliente Cliente { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var prod1 = new Produto { Nome = "Notebook", Preco = 3500.00m };
            var prod2 = new Produto { Nome = "Mouse", Preco = 150.00m };
            var prod3 = new Produto { Nome = "Teclado", Preco = 250.00m };

            var cli1 = new Cliente { Nome = "Alice", Cpf = "111.111.111-11" };
            var cli2 = new Cliente { Nome = "Bruno", Cpf = "222.222.222-22" };

            List<Pedido> pedidos = new List<Pedido>
            {
                new Pedido { Cliente = cli1, Produto = prod1, Quantidade = 1, DataPedido = DateTime.Now },
                new Pedido { Cliente = cli1, Produto = prod2, Quantidade = 2, DataPedido = DateTime.Now },
                new Pedido { Cliente = cli2, Produto = prod2, Quantidade = 1, DataPedido = DateTime.Now },
                new Pedido { Cliente = cli2, Produto = prod3, Quantidade = 3, DataPedido = DateTime.Now }
            };

            Console.WriteLine("--- Exercício 4 ---\n");

            var pedidosAgrupadosPorCliente = pedidos.GroupBy(p => p.Cliente.Nome);
            
            Console.WriteLine("1. Pedidos Agrupados por Cliente:");
            foreach (var grupo in pedidosAgrupadosPorCliente)
            {
                Console.WriteLine($"   Cliente: {grupo.Key}");
                foreach (var pedido in grupo)
                {
                    Console.WriteLine($"     - {pedido.Quantidade}x {pedido.Produto.Nome}");
                }
            }

            var clientesComPedidosAcima500 = pedidos
                .Where(p => (p.Produto.Preco * p.Quantidade) > 500)
                .Select(p => p.Cliente.Nome)
                .Distinct() 
                .ToList();

            Console.WriteLine("\n2. Clientes com pedidos (itens individuais) acima de R$ 500:");
            clientesComPedidosAcima500.ForEach(nome => Console.WriteLine($"   - {nome}"));

            var totalPorCliente = pedidos
                .GroupBy(p => p.Cliente.Nome)
                .Select(grupo => new
                {
                    NomeCliente = grupo.Key,
                    ValorTotal = grupo.Sum(p => p.Produto.Preco * p.Quantidade)
                })
                .ToList();

            Console.WriteLine("\n3. Valor Total de Pedidos por Cliente:");
            foreach (var total in totalPorCliente)
            {
                Console.WriteLine($"   Cliente: {total.NomeCliente} | Total Gasto: R$ {total.ValorTotal:F2}");
            }
        }
    }
}