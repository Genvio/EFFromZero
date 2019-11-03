using System.Data.Entity;

namespace Chapter_3.Core
{
    public class BookContext : DbContext
    {
        static BookContext()
        {
            Database.SetInitializer<BookContext>(new DBInittializer());
        }

        public BookContext() : base("DBConnection") { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AdvancedBook> AdvancedBooks { get; set; }

        public DbSet<Mother> Mothers { get; set; }
        public DbSet<Child> Children { get; set; }

        public DbSet<NewBook> NewBooks { get; set; }
        public DbSet<NewAuthor> NewAuthors { get; set; }

        public DbSet<DateTimeOfRun> Runs { get; set; }
    }
}
