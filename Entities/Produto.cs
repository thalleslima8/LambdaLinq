using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Entities {
    class Produto {

        public string Name { get;private set; }
        public double Price { get;private set; }
        public int Quantity { get;private set; }

        public Produto(string name, double price, int quantity) {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        private string testaQuantidade() {
            if(this.Quantity > 1) {
                return " Unidades";
            } else {
                return " Unidade";
            }
        }

        public override string ToString() {
            return "Nome: " + Name
                + ", Preço: R$ " + Price.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantidade: " + Quantity +  
                testaQuantidade();
        }
    }
}
