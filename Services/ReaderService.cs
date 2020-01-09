using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Services {
    class ReaderService {


        public string Path { get; set; }

        public ReaderService(string path) {
            Path = path;
        }

        public List<Produto> LerProdutos() {
            
            List<Produto> produtos = new List<Produto>();

            try {
                using (StreamReader sr = File.OpenText(Path)) {
                    while (!sr.EndOfStream) {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        produtos.Add(new Produto(name, price, quantity));
                    }
                }
            } catch(IOException e) {
                Console.WriteLine("Erro: ");
                Console.WriteLine(e.Message);
            }

            return produtos;
        }
    }
}
