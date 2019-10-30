using System;

namespace Chapter_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //add users
            Console.WriteLine("Start create the database and fill the users.");
            using(Core.UserContext context = new Core.UserContext())
            {
                context.Users.Add(new Core.User
                {
                    Name = "Boris",
                    Birddate = new DateTime(1972, 10, 2),
                    Address = "Ukraine, Kharkiv area, Lenina str. 7/6"
                });

                context.Users.Add(new Core.User
                {
                    Name = "Ivan",
                    Birddate = new DateTime(2001, 12, 21),
                    Address = "Ukraine, Kharkiv area, Shevchenko str. 23/33"
                });

                int changes = context.SaveChanges();
                Console.WriteLine($"Saved {changes} changes in the database.");
            }


            //read users
            Console.WriteLine("Read the users from the database. Users:");
            using (Core.UserContext context = new Core.UserContext())
            {
                int i = 1;
                foreach (var user in context.Users)
                {
                    Console.WriteLine($"{i}. {user.Name}, age - {DateTime.Now.Year - user.Birddate.Year}, live at {user.Address}");
                    i++;
                }
            }

            Console.Read();
        }
    }
}
