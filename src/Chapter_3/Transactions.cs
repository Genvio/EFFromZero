using Chapter_3.Core;
using System;

namespace Chapter_3
{
    class Transactions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Transaction.");
            using(var db = new BookContext())
            using (var transaction = db.Database.BeginTransaction())
                try
                {
                    //one transaction
                    db.Books.Add(new Book { Name = "1984" });
                    db.Authors.Add(new Author { FirstName = "Jhon" });
                }
                catch
                {
                    //if exception - rollback the transaction
                    transaction.Rollback();
                }

            Console.ReadLine();
        }
    }
}
