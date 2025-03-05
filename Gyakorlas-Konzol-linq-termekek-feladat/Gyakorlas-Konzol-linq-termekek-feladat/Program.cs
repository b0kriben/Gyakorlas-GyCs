using System.Text.RegularExpressions;
using System;
using System.Linq;
using Gyakorlas_Model_es_konzol_Termekek_feladat.Models;
using Gyakorlas_Model_es_konzol_Termekek_feladat.Repos;

class Program
{
    //1.Számlálási(Count) feladatok
    static void Main1()
    {
        ProductRepo repo = new ProductRepo();
        var products = new List<Product>
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

        // 1. Három termék összes száma a raktárban
        int totalProducts = repo.ListProducts().Count();
        Console.WriteLine($"A raktárban összesen {totalProducts} termék található.");

        // 2. Kategória szerinti számolás (például 'Élelmiszer')
        string category = "Élelmiszer";
        int countByCategory = repo.ListProducts().Count(p => p.Category == category);
        Console.WriteLine($"A '{category}' kategóriában {countByCategory} termék található.");

        // 3. Ár szerint számolás (például 500 Ft felett)
        decimal priceLimit = 500;
        int countByPrice = repo.ListProducts().Count(p => p.Price > priceLimit);
        Console.WriteLine($"Az árnál nagyobb, mint {priceLimit} Ft: {countByPrice} termék.");
    }




    //2.Szűrési(Where) feladatok
    static void Main2()
    {
        ProductRepo repo = new ProductRepo();
        var products = new List<Product>
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

        // 1. Listázza azokat a termékeket, amelyek ára 500 Ft alatt van
        decimal maxPrice = 500;
        var filteredByPrice = repo.ListProducts().Where(p => p.Price < maxPrice);
        Console.WriteLine($"Termékek, amelyek ára {maxPrice} Ft alatt van:");
        foreach (var product in filteredByPrice)
        {
            Console.WriteLine(product);
        }

        // 2. Mennyiség szerinti szűrés (pl. 5 db alatti)
        int minQuantity = 5;
        var filteredByQuantity = repo.ListProducts().Where(p => p.Quantity < minQuantity);
        Console.WriteLine($"Termékek, amelyek mennyisége {minQuantity} db alatti:");
        foreach (var product in filteredByQuantity)
        {
            Console.WriteLine(product);
        }

        // 3. Kategória szerinti szűrés (pl. 'Élelmiszer')
        string category = "Élelmiszer";
        var filteredByCategory = repo.ListProducts().Where(p => p.Category == category);
        Console.WriteLine($"Termékek a '{category}' kategóriában:");
        foreach (var product in filteredByCategory)
        {
            Console.WriteLine(product);
        }

        // 4. Azokat a termékeket, amelyek neve adott betűvel kezdődik (pl. 'T')
        string startsWith = "T";
        var filteredByName = repo.ListProducts().Where(p => p.Name.StartsWith(startsWith));
        Console.WriteLine($"Termékek, amelyek neve '{startsWith}' betűvel kezdődik:");
        foreach (var product in filteredByName)
        {
            Console.WriteLine(product);
        }

        // 5. Azok a termékek, amelyek ára egy adott tartományban van
        decimal priceMin = 200;
        decimal priceMax = 500;
        var filteredByPriceRange = repo.ListProducts().Where(p => p.Price >= priceMin && p.Price <= priceMax);
        Console.WriteLine($"Termékek, amelyek ára {priceMin} Ft és {priceMax} Ft között van:");
        foreach (var product in filteredByPriceRange)
        {
            Console.WriteLine(product);
        }
    }





    //3.Distinct(Egyedi értékek) feladatok
    static void Main3()
    {
        ProductRepo repo = new ProductRepo();
        var products = new List<Product>
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

        // 1. Különböző kategóriák listázása
        var distinctCategories = repo.ListProducts().Select(p => p.Category).Distinct();
        Console.WriteLine("Különböző kategóriák:");
        foreach (var category in distinctCategories)
        {
            Console.WriteLine(category);
        }
    }




    //4.Csoportosítás(Group By) feladatok
    static void Main4()
    {
        ProductRepo repo = new ProductRepo();
        var products = new List<Product>
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

        // 1. Csoportosítás kategóriák szerint
        var groupedByCategory = repo.ListProducts()
            .GroupBy(p => p.Category)
            .Select(g => new { Category = g.Key, Count = g.Count() });

        Console.WriteLine("Termékek kategória szerinti csoportosítása:");
        foreach (var group in groupedByCategory)
        {
            Console.WriteLine($"{group.Category}: {group.Count} termék");
        }

        // 2. Csoportosítás ár szerint (<500 és >500)
        var groupedByPrice = repo.ListProducts()
            .GroupBy(p => p.Price < 500 ? "500 Ft alatti" : "500 Ft feletti")
            .Select(g => new { PriceGroup = g.Key, Count = g.Count() });

        Console.WriteLine("\nTermékek ár szerinti csoportosítása:");
        foreach (var group in groupedByPrice)
        {
            Console.WriteLine($"{group.PriceGroup}: {group.Count} termék");
        }
    }
}
