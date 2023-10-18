namespace ContactListWeb.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        virtual public Category Category { get; set; } = null!;

        virtual public ICollection<Contact> Contacts { get; set; } = null!;
    }
}
