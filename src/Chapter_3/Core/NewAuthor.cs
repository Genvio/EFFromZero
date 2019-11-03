using System.Collections.Generic;

namespace Chapter_3.Core
{
    public class NewAuthor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NewBook> NewBooks { get; set; }

        public NewAuthor()
        {
            NewBooks = new List<NewBook>();
        }
    }
}
