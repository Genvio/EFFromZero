using System.Collections.Generic;

namespace Chapter_3.Core
{
    public class AdvancedBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
