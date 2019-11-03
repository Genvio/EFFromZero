using System;
using System.Linq;
using Chapter_3.Core;

namespace Chapter_3
{
    class CRUD
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CRUD operatios.");
            Console.WriteLine("Create.");

            using (var db = new BookContext())
            {
                db.Books.Add(new Book
                {
                    Name = "1984",
                    Author = "Orwell",
                    Price = 19.95M,
                    Count = 15
                });

                db.Books.Add(new Book
                {
                    Name = "Lolita",
                    Author = "Nabokov",
                    Price = 59.99M,
                    Count = 47
                });

                db.Books.Add(new Book
                {
                    Name = "Sherlock Holmes",
                    Author = "Doyle",
                    Price = 9.99M,
                    Count = 1
                });

                db.SaveChanges();
            }

            Console.WriteLine("Read.");

            int i = 1;
            Console.WriteLine($"#. Book\t\t\t\t\tCount\tPrice\tTotalvalue");
            using (var db = new BookContext())
                foreach (var b in db.Books)
                    Console.WriteLine($"{i++}. {b.Name} - {b.Author}\t\t\t{b.Count}\t{b.Price}\t{(b.Count * b.Price).ToString("#0.00")}");

            Console.WriteLine("Update.");
            using (var db = new BookContext())
            {
                db.Books.FirstOrDefault(x => x.Author == "Orwell").Price = 22.45M;
                db.SaveChanges();
            }

            Console.WriteLine("Update in other context #1");
            Book book = null;
            using (var db = new BookContext())
                book = db.Books.FirstOrDefault(x => x.Author == "Nabokov");

            using (var db = new BookContext())
            {
                book.Count--;
                db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            Console.WriteLine("Update in other context #2");
            using (var db = new BookContext())
                book = db.Books.FirstOrDefault(x => x.Author == "Orwell");

            using (var db = new BookContext())
            {
                db.Books.Attach(book);
                book.Price = 19.45M;
                db.SaveChanges();
            }

            Console.WriteLine("Delete (deleting from othet context also works).");
            using (var db = new BookContext())
            {
                var b = db.Books.FirstOrDefault(x => x.Author == "Doyle");
                db.Books.Remove(b);
                db.SaveChanges();
            }

            Console.WriteLine("Read again.");
            i = 1;
            Console.WriteLine($"#. Book\t\t\t\t\tCount\tPrice\tTotal value");
            using (var db = new BookContext())
                foreach (var b in db.Books)
                    Console.WriteLine($"{i++}. {b.Name} - {b.Author}\t\t\t{b.Count}\t{b.Price}\t{(b.Count * b.Price).ToString("#0.00")}");

            Console.ReadLine();
        }
    }
}
