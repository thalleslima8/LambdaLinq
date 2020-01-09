using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Entities;
using Services;

namespace LambdaLinq {
    class Program {
        static void Main(string[] args) {
                       
            Console.WriteLine("Digite o caminho do arquivo fonte: ");
            string path = Console.ReadLine();

            ReaderService rs = new ReaderService(path);
            List<Produto> produtos = new List<Produto>();
            
            produtos = rs.LerProdutos();

            Console.WriteLine("Lista de Produtos: \n");
            foreach(Produto p in produtos) {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            var avg = produtos.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Preço Medio: " + avg.ToString("F2", CultureInfo.InvariantCulture) + "\n");

            var names = produtos.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
            Console.WriteLine("Itens com preço abaixo da media: ");
            foreach(string name in names) {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            Console.WriteLine("Digite um valor para filtro: ");
            double filtro = double.Parse(Console.ReadLine());

            var valores = produtos.Where(p => p.Price < filtro).OrderBy(p => p.Price);
            Console.WriteLine("Produtos menores que R$ " + filtro);
            foreach(Produto p in valores) {
                Console.WriteLine(p);
            }
            Console.WriteLine();


            Console.WriteLine("Digite um caracter para filtro: ");
            char ch = char.Parse(Console.ReadLine());

            var carac = produtos.Where(p => p.Name.ElementAt(0) == ch);
            foreach (Produto p in carac) {
                Console.WriteLine(p);
            }

                     

            Console.WriteLine("Soma: " + carac.Select(p => p.Price).Sum());


        }
    }
}
