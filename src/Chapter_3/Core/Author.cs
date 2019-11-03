namespace Chapter_3.Core
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public int? AdvancedBookId { get; set; }
        public virtual AdvancedBook AdvancedBook { get; set; }
    }
}
