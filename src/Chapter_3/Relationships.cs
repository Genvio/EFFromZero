using Chapter_3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_3
{
    class Relationships
    {
        static void Main(string[] args)
        {
            Console.WriteLine("One-to-one");
            using (var db = new BookContext())
            {
                Mother m1 = new Mother { Name = "Marry" };
                Mother m2 = new Mother { Name = "Jany" };

                db.Mothers.Add(m1);
                db.Mothers.Add(m2);

                db.SaveChanges();

                Child c1 = new Child { Id = m1.Id, Name = "Jhon" };
                Child c2 = new Child { Id = m2.Id, Name = "Jack" };

                db.Children.Add(c1);
                db.Children.Add(c2);

                db.SaveChanges();
            }

            using (var db = new BookContext())
                foreach (var mother in db.Mothers.Include("Child").ToList())
                    Console.WriteLine($"Mother {mother.Name} and her kid {mother.Child.Name}");

            Console.WriteLine("Many-to-many");
            using(var db = new BookContext())
            {
                NewAuthor ilf = new NewAuthor  {  Name = "Ilya Ilf" };
                NewAuthor petrov = new NewAuthor  {  Name = "Evgeny Petrov" };
                NewAuthor gaiman = new NewAuthor  {  Name = "Neil Gaiman" };
                NewAuthor pratchett = new NewAuthor  {  Name = "Terry Pratchett" };
                NewAuthor jolliffe = new NewAuthor  {  Name = "Gray Jolliffe" };

                db.NewAuthors.Add(ilf);
                db.NewAuthors.Add(petrov);
                db.NewAuthors.Add(gaiman);
                db.NewAuthors.Add(pratchett);
                db.NewAuthors.Add(jolliffe);

                db.SaveChanges();

                NewBook osa = new NewBook { Name = "One-story America" };
                NewBook go = new NewBook { Name = "Good omens" };
                NewBook tuc = new NewBook { Name = "The Unadulterated Cat" };

                osa.NewAuthors.Add(ilf);
                osa.NewAuthors.Add(petrov);

                go.NewAuthors.Add(gaiman);
                go.NewAuthors.Add(pratchett);

                tuc.NewAuthors.Add(pratchett);
                tuc.NewAuthors.Add(jolliffe);

                db.NewBooks.Add(osa);
                db.NewBooks.Add(go);
                db.NewBooks.Add(tuc);

                db.SaveChanges();
            }

            Console.WriteLine("Books with authors:");
            int i = 1;
            using (var db = new BookContext())
                foreach (var book in db.NewBooks)
                {
                    Console.WriteLine($"{i++}. {book.Name}");
                    using(var middleContext = new BookContext())
                    {
                        var b = middleContext.NewBooks.FirstOrDefault(x => x.Id == book.Id);
                        foreach (var author in b.NewAuthors)
                            Console.WriteLine($"\t{author.Name}");
                    }
                }

            Console.WriteLine("Authors with books:");
            i = 1;
            using (var db = new BookContext())
                foreach (var author in db.NewAuthors)
                {
                    Console.WriteLine($"{i++}. {author.Name}");
                    using (var middleContext = new BookContext())
                    {
                        var a = middleContext.NewAuthors.FirstOrDefault(x => x.Id == author.Id);
                        foreach (var book in a.NewBooks)
                            Console.WriteLine($"\t{book.Name}");
                    }
                }

            Console.ReadLine();
        }
    }
}
