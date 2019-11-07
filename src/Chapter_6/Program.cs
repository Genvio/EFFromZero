using Chapter_6.Core;
using System;
using System.Linq;

namespace Chapter_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Table Per Hierarchy");

            using (var db = new DatabaseContext())
            {
                db.Animals.Add(new Animal
                {
                    AnimaClass = "Class #1"
                });

                db.Dogs.Add(new Dog
                {
                    AnimaClass = "Class #2",
                    Age = 3
                });

                db.SaveChanges();
            }

            using (var db = new DatabaseContext())
            {
                var animal = db.Animals.First();
                var dog = db.Dogs.First();

                Console.WriteLine($"Animal, class: {animal.AnimaClass}");
                Console.WriteLine($"Dog, class: {dog.AnimaClass}, age: {dog.Age}");
            }

            Console.WriteLine("Table Per Type");

            using (var db = new DatabaseContext())
            {
                db.Cats.Add(new Cat
                {
                    Age = 12
                });

                db.BigCats.Add(new BigCat
                {
                    Age = 44,
                    Name = "Pussy"
                });

                db.SaveChanges();
            }

            using (var db = new DatabaseContext())
            {
                var cat = db.Cats.First();
                var bigCat = db.BigCats.First();

                Console.WriteLine($"Cat, age: {cat.Age}");
                Console.WriteLine($"Big cat, age: {bigCat.Age}, name: {bigCat.Name}");
            }

            Console.WriteLine("Table Per Concrete Type");

            using (var db = new DatabaseContext())
            {
                db.Slimes.Add(new Slime
                {
                    Size = 57
                });

                db.ColoredSlimes.Add(new ColoredSlime
                {
                    Size = 33,
                    Color = "Red"
                });

                db.SaveChanges();
            }

            using (var db = new DatabaseContext())
            {
                var slime = db.Slimes.First();
                var coloredSlime = db.ColoredSlimes.First();

                Console.WriteLine($"Slime, size: {slime.Size}");
                Console.WriteLine($"Colored slime, size: {coloredSlime.Size}, color: {coloredSlime.Color}");
            }

            Console.ReadLine();
        }
    }
}
