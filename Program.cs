using EF_01.Data;
using EF_01.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_01
{
    internal class Program
    {
        static void Main(string[] args)
        {


            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Database.Migrate();

                Console.WriteLine("Database Created Successfully!");

                // Create Category
                var category = new Category
                {
                    Name = "Programming",
                    Description = "Programming and Computer Science Books",
                    IsActive = true
                };

                // Create Author
                var author = new Author
                {
                    FirstName = "Ahmed",
                    LastName = "Mohamed",
                    Email = "ahmed@example.com",
                    Biography = "Software Developer and Author",
                    DateOfBirth = new DateTime(1990, 5, 10)
                };

                // Create Book
                var book = new Book
                {
                    Title = "Learn C# Programming",
                    ISBN = "9781234567890",
                    Price = 350.50m,
                    NumberOfPages = 400,
                    PublishedYear = 2025,
                    IsInStock = true,
                    Category = category,
                    Authors = new List<Author> { author }
                };

                context.Books.Add(book);

                context.SaveChanges();

                Console.WriteLine("Sample Data Inserted Successfully!");

                // Display Books
                var books = context.Books
                    .Include(b => b.Category)
                    .Include(b => b.Authors)
                    .ToList();

                foreach (var item in books)
                {
                    Console.WriteLine($"Title: {item.Title}");
                    Console.WriteLine($"Price: {item.Price}");
                    Console.WriteLine($"Category: {item.Category.Name}");

                    foreach (var itemAuthor in item.Authors)
                    {
                        Console.WriteLine($"Author: {itemAuthor.FullName}");
                    }

                    Console.WriteLine("----------------------");
                }
            }
        }
    }
}
