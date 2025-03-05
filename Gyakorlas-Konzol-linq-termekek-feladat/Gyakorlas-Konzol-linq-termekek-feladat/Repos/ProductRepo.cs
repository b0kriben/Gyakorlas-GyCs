using Gyakorlas_Model_es_konzol_Termekek_feladat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlas_Model_es_konzol_Termekek_feladat.Repos
{
    public class ProductRepo
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            if (product.Quantity > 0)
            {
                products.Add(product);
            }
            else
            {
                Console.WriteLine("A termék mennyiségének nagyobbnak kell lennie, mint 0.");
            }
        }

        public void RemoveProduct(Product product)
        {
            if (product.Quantity == 0)
            {
                products.Remove(product);
            }
            else
            {
                Console.WriteLine("A termék mennyiségének 0-nak kell lennie a törléshez.");
            }
        }

        public void ListProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}
