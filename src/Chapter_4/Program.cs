using Chapter_4.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple select #1");
            using (var db = new SimpleDataContext())
                foreach (var item in (from i in db.SimpleDatas
                                      where i.Name.EndsWith("1")
                                      select i))
                    Console.WriteLine(item.Name);

            Console.WriteLine("\nSimple select #2");
            using (var db = new SimpleDataContext())
                foreach (var item in db.SimpleDatas.Where(x => x.Name.Contains("2")))
                    Console.WriteLine(item.Name);

            Console.WriteLine("Firs load all data then filter.");
            using (var db = new SimpleDataContext())
            {
                IEnumerable<SimpleData> datas = db.SimpleDatas;
                foreach (var item in datas.Where(x => x.Id % 2 == 0).ToList())
                    Console.WriteLine(item.Name);
            }

            Console.WriteLine("Load partial data by filter.");
            using (var db = new SimpleDataContext())
            {
                IQueryable<SimpleData> datas = db.SimpleDatas;
                foreach (var item in datas.Where(x => x.Id % 3 == 0).ToList())
                    Console.WriteLine(item.Name);
            }

            Console.WriteLine("AsNoTracking");
            using (var db = new SimpleDataContext())
            {
                IQueryable<SimpleData> datas = db.SimpleDatas.AsNoTracking();
                foreach (var item in datas.Where(x => x.Id % 33 == 0).ToList())
                    Console.WriteLine(item.Name);
            }

            Console.Read();
        }
    }
}
