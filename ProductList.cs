using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LexWeek02MiniProject
{
    public class ProductList
    {
        public string category;
        public string product;
        public int price;
        public List<ProductList> products;
        public ProductList() { products = new List<ProductList>(); }
        public ProductList(string category, string product, int price) 
        {
            this.category = category;
            this.product = product;
            this.price = price;

        }
        
        public string CreateItem() 
        {
            string category = GetCategory();
            string product = GetProduct();
            int price = GetPrice();
            ProductList newItem = new ProductList(category, product, price);
            products.Add(newItem);
            if (products.Contains(newItem))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have successfully added a product!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product failed..!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return $"{category} - {product} added successfully!";
        }

        public void ShowSearchedProduct()
        {
            
            Console.Write("Enter the product you are looking: ");
            string answer = Console.ReadLine();
            var matchingProducts = products
                .Where(product => product.product.Contains(answer, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{"Category",-20}{"Product",-20}{"Price",-20}");
            products
                .OrderBy(product => product.price)
                //.Select(product => $"{product.category,-20}{product.product,-20}{product.price,-20}")
                .ToList()
                .ForEach(product =>
                {
                    if (matchingProducts.Contains(product))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();
                    Console.WriteLine($"{product.category,-20}{product.product,-20}{product.price,-20}");
                    Console.ForegroundColor = ConsoleColor.White;
                });
            
        }
        public void PrintInfo()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{"Category",-20}{"Product",-20}{"Price",-20}");
            products
                .OrderBy(product => product.price)
                .Select(product => $"{product.category,-20}{product.product,-20}{product.price,-20}")
                .ToList()
                .ForEach(Console.WriteLine);
            Console.WriteLine();
            
            int totalSum = products.Sum(product => product.price);
            Console.WriteLine($"{"",-20}{"Total",-20} {totalSum,-20}");
            Console.WriteLine(new string('-', 50));
        }
        public string GetCategory() 
        {
            while (true) {
                Console.Write("Whats the category?: ");
                string categ = Console.ReadLine();
                if (categ == null)
                { Console.WriteLine("Please write something.."); continue; }
                else {
                    category = categ;
                    return categ;
                }
            }
            
        }
        public string GetProduct()
        {
            while (true)
            {
                Console.Write("Whats the product?: ");
                string produ = Console.ReadLine();
                if (produ == null)
                { Console.WriteLine("Please write something.."); continue; }
                else
                {
                    product = produ;
                    return product;
                }
            }
        }
        public int GetPrice() 
        {
            while (true)
            {
                Console.Write("Whats the price?: ");
                string custPrice = Console.ReadLine();
                if (int.TryParse(custPrice, out int result))
                {
                    price = result;
                    return result;
                }
                else
                {
                    Console.WriteLine("Not a number. Please enter an integer");
                    continue;
                }

            }
        }
    }
}
