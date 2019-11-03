using Chapter_3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_3
{
    class DataLoading
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data loading and on-to-many examples.");

            using (var db = new BookContext())
            {
                Author ilf = new Author
                {
                    FirstName = "Ilya",
                    SecondName = "Ilf"
                };
                Author petrov = new Author
                {
                    FirstName = "Evgeny",
                    SecondName = "Petrov"
                };
                Author gaiman = new Author
                {
                    FirstName = "Neil",
                    SecondName = "Gaiman"
                };
                Author pratchett = new Author
                {
                    FirstName = "Terry",
                    SecondName = "Pratchett"
                };

                db.Authors.Add(ilf);
                db.Authors.Add(petrov);
                db.Authors.Add(gaiman);
                db.Authors.Add(pratchett);

                AdvancedBook osa = new AdvancedBook
                {
                    Count = 55,
                    Name = "One-story America",
                    Price = 11.45M,
                    Authors = new List<Author>
                    {
                        ilf,
                        petrov
                    }
                };
                AdvancedBook go = new AdvancedBook
                {
                    Count = 1,
                    Name = "Good omens",
                    Price = 60,
                    Authors = new List<Author>
                    {
                        gaiman,
                        pratchett
                    }
                };

                db.AdvancedBooks.Add(osa);
                db.AdvancedBooks.Add(go);

                db.SaveChanges();
            }

            Console.WriteLine("Eager loading.");
            using (var db = new BookContext())
            {
                List<AdvancedBook> books = db.AdvancedBooks.Include("Authors").ToList();
                int i = 1;
                foreach (var book in books)
                {
                    Console.WriteLine($"{i++}. {book.Name}");
                    Console.WriteLine("\tAuthors:");
                    foreach (var author in book.Authors)
                        Console.WriteLine($"\t\t{author.FirstName} {author.SecondName}");
                }
            }

            Console.WriteLine("Explicit loading.");
            using (var db = new BookContext())
            {
                Console.WriteLine("First book:");
                var book = db.AdvancedBooks.First();

                db.Entry(book).Collection("Authors").Load();

                Console.WriteLine(book.Name);
                Console.WriteLine("\tAuthors:");
                foreach (var author in book.Authors)
                    Console.WriteLine($"\t\t{author.FirstName} {author.SecondName}");


            }
            using (var db = new BookContext())
            {
                int i = 1;
                Console.WriteLine("First author:");
                var author = db.Authors.First();
                db.Entry(author).Reference("AdvancedBook").Load();
                Console.WriteLine($"{i++}. {author.FirstName} {author.SecondName} - {author.AdvancedBook.Name}");
            }

            Console.WriteLine("Lazy loading, navigation properties must be virtual and the classes are public");
            using (var db = new BookContext())
            {
                Console.WriteLine("First book:");
                var book = db.AdvancedBooks.First();
                Console.WriteLine(book.Name);
                Console.WriteLine("\tAuthors:");
                foreach (var author in book.Authors)
                    Console.WriteLine($"\t\t{author.FirstName} {author.SecondName}");


            }
            using (var db = new BookContext())
            {
                int i = 1;
                Console.WriteLine("First author:");
                var author = db.Authors.First();
                Console.WriteLine($"{i++}. {author.FirstName} {author.SecondName} - {author.AdvancedBook.Name}");
            }

            Console.ReadLine();
        }
    }
}
