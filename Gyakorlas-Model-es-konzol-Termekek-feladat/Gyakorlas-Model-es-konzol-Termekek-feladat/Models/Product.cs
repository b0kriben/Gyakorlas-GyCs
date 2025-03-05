using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlas_Model_es_konzol_Termekek_feladat.Models
{
    public class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string Category { get; private set; }

        public Product(string name, string category)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("A termék neve nem lehet üres.");
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("A termék kategóriája nem lehet üres.");

            Name = name;
            Category = category;
            Price = 0;
            Quantity = 0;
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("Az ár nem lehet negatív.");
            Price = price;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentException("A mennyiség nem lehet negatív.");
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Name} ({Category}) - Ár: {Price} Ft, Mennyiség: {Quantity}";
        }
    }
}
