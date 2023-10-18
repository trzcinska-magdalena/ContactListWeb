using ContactListWeb.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ContactListWeb.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Surname { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [ComplexityOfPassword]
        public string Password { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
        [Required]
        [PastDate]
        public DateTime BirthDate { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public int? SubcategoryID { get; set; }

        public string? SubcategoryOther { get; set; }
        virtual public Category? Category { get; set; }
        virtual public Subcategory? Subcategory { get; set; }
    }
}
