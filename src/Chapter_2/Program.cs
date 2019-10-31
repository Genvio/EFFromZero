using System;

namespace Chapter_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read data from existing database

            Console.WriteLine("Users:");
            using (DBModel db = new DBModel())
                foreach (Users u in db.Users)
                    Console.WriteLine("{0}.{1} - {2}", u.ID, u.Name, u.Birddate.ToShortDateString());

            Console.Read();
        }
    }
}
