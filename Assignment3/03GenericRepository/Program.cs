/* C# Assignment 03
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 29th, 2024
*/

/*
3. Implement a GenericRepository<T> class that implements IRepository<T> interface
that will have common /CRUD/ operations so that it can work with any data source
such as SQL Server, Oracle, In-Memory Data etc. Make sure you have a type constraint
on T were it should be of reference type and can be of type Entity which has one
property called Id. IRepository<T> should have following methods
1. void Add(T item)
2. void Remove(T item)
3. Void Save()
4. IEnumerable<T> GetAll()
5. T GetById(int id)
*/


using System;
using System.Collections.Generic;

namespace GenericRepositoryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a repository for Product
            IRepository<Product> productRepository = new GenericRepository<Product>();

            // Add products
            productRepository.Add(new Product { Id = 1, Name = "Laptop", Price = 999.99m });
            productRepository.Add(new Product { Id = 2, Name = "Smartphone", Price = 499.99m });

            // Save changes (In this in-memory example, it doesn't do anything)
            productRepository.Save();

            // Get all products
            IEnumerable<Product> products = productRepository.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
            }

            // Get product by Id
            Product productById = productRepository.GetById(1);
            if (productById != null)
            {
                Console.WriteLine($"Found product with Id 1: {productById.Name}, Price: {productById.Price}");
            }

            // Remove a product
            productRepository.Remove(productById);
            productRepository.Save();

            // Check if the product was removed
            products = productRepository.GetAll();
            Console.WriteLine("Products after removal:");
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
            }
        }
    }
}
