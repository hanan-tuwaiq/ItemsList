using System;
using System.Collections.Generic;

namespace ItemsList
{
    class Program
    {
        class Product
        {
            public int id;
            public string name;
            public double price;

            public Product(int id, string name, double price)
            {
                this.id = id;
                this.name = name;
                this.price = price;
            }
            public Product()
            {

            }
            public List<Product> productsList()
            {
                List<Product> products = new List<Product>();
                products.Add(new Product(10,"Royal canin Indoor", 77.00));
                products.Add(new Product(20, "Birbo Premium Cat Blend", 175.00));
                products.Add(new Product(30, "Applaws tuna fillet", 131.50));
                products.Add(new Product(40, "Butcher's Cat With Chicken 400g Can", 6.75));
                products.Add(new Product(50, "Schesir Cat Tuna & Whitebait 85g Tin", 6.00));
                return products;
            }
            public void displayMenu()
            {
                List<Product> products = productsList();
                Console.WriteLine("=====( Cat Food: )=====");
                foreach(Product p in products)
                {
                    Console.WriteLine(p.id+". "+p.name+" Price: "+p.price);
                }
            }
        }
        class Cart
        {
            public Cart()
            {

            }
     
            public List<Product> shop()
            {
                List<Product> allProducts = new Product().productsList();
                List<Product> cart = new List<Product>();
                string operation = "";
                do
                {
                    Console.WriteLine("Add a product \t Remove a product");
                    operation = Console.ReadLine();
                    if (operation.Equals("add"))
                    {
                        //add an item
                        Console.WriteLine("Enter product id to add");
                        int id = Convert.ToInt32(Console.ReadLine());
                        foreach(var p in allProducts)
                        {
                            if(id == p.id)
                            {
                                cart.Add(p);
                                Console.WriteLine("Added!");
                                break;
                            }
                        }
                        continue;
                    }
                    else if (operation.Equals("remove"))
                    {
                        if(cart == null)
                        {
                            Console.WriteLine("Your cart is empty!");
                        } else
                        {
                            Console.WriteLine("Enter product id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            foreach (var p in allProducts)
                            {
                                if (id == p.id)
                                {
                                    cart.Remove(p);
                                    Console.WriteLine("Removed!");
                                }
                            }
                        }
                        continue;
                    }
                    else
                    {
                        break;
                    }
                } while (!operation.Equals("exit"));
                return cart;
            }
            public void totalAmount(List<Product> cart)
            {
                double total = 0;
                Console.WriteLine("=====( Cart )=====");
                foreach(var p in cart)
                {
                    Console.WriteLine(p.id + ". " + p.name + " Price: " + p.price);
                    total += p.price;
                }
                if(total >= 200)
                {
                    Console.WriteLine("Total after discount: "+ (total - (total * 0.1)));
                }
                else
                {
                    Console.WriteLine("Total: " + total);
                }
            }
        }
        static void Main(string[] args)
        {
            Product p = new Product();
            p.displayMenu();
            Cart c = new Cart();
            List<Product> products = c.shop();
            c.totalAmount(products);
        }
    }
}
