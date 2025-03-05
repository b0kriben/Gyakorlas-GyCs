using Gyakorlas_Model_es_konzol_Termekek_feladat.Models;
using Gyakorlas_Model_es_konzol_Termekek_feladat.Repos;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ProductRepo repo = new ProductRepo();

        List<Product> products = new List<Product>
        {
            new Product("Tej", "Élelmiszer"),
            new Product("Kenyér", "Élelmiszer"),
            new Product("Vaj", "Élelmiszer"),
            new Product("Sajt", "Élelmiszer"),
            new Product("Alma", "Gyümölcs"),
            new Product("Banán", "Gyümölcs"),
            new Product("Kávé", "Ital"),
            new Product("Tea", "Ital"),
            new Product("Cukor", "Fűszer"),
            new Product("Só", "Fűszer")
        };

        Random rand = new Random();
        foreach (var product in products)
        {
            product.SetPrice(rand.Next(100, 1000));
            product.SetQuantity(rand.Next(1, 20));
            repo.AddProduct(product);
        }

        Console.WriteLine("Termékek a raktárban:");
        repo.ListProducts();

        var productToRemove = products[0];
        productToRemove.SetQuantity(0);
        repo.RemoveProduct(productToRemove);

        Console.WriteLine("\nA raktár a törlés után:");
        repo.ListProducts();
    }
}