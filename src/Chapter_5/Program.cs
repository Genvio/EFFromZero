using Chapter_5.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data before migration:");
            using (var db = new DatabaseContext())
                foreach (var item in db.Datas.AsNoTracking().Where(x => x.Name.EndsWith("2")))
                    Console.WriteLine($"{item.Name} RecDate: {item.RecDate}");

            Console.WriteLine("Data after migration:");
            using (var db = new DatabaseContext())
                foreach (var item in db.Datas.AsNoTracking().Where(x => x.Name.EndsWith("2")))
                    Console.WriteLine($"{item.Name} RecDate: {item.RecDate}, Age: {item.Age}");

            Console.ReadLine();
        }
    }
}
