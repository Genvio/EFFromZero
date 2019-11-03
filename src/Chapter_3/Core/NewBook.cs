using System.Collections.Generic;

namespace Chapter_3.Core
{
    public class NewBook
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NewAuthor> NewAuthors { get; set; }

        public NewBook()
        {
            NewAuthors = new List<NewAuthor>();
        }
    }
}
