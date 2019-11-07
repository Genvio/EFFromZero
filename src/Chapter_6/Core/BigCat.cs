using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter_6.Core
{
    [Table("BigCats")]
    public class BigCat : Cat
    {
        public string Name { get; set; }
    }
}
