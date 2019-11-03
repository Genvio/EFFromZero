using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter_3.Core
{
    public class Child
    {
        [Key]
        [ForeignKey("Mother")]
        public int Id { get; set; }
        public string Name { get; set; }

        public Mother Mother { get; set; }
    }
}
