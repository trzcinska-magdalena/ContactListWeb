namespace ContactListWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        virtual public ICollection<Subcategory> Subcategories { get; set; } = null!;
        virtual public ICollection<Contact> Contacts { get; set; } = null!;
    }
}
