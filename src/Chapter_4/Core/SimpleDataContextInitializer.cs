using System.Data.Entity;

namespace Chapter_4.Core
{
    public class SimpleDataContextInitializer : DropCreateDatabaseAlways<SimpleDataContext>
    {
        protected override void Seed(SimpleDataContext db)
        {
            for (int i = 1; i < 101; i++)
                db.SimpleDatas.Add(new SimpleData
                {
                    Name = "SimpleData #" + i
                });

            db.SaveChanges();
        }
    }
}
