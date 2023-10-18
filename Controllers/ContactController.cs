using ContactListWeb.Data;
using ContactListWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactListWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactListWebContext _context;

        public ContactController(ContactListWebContext context)
        {
            _context = context;
        }

        // GET /contact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact?>> GetContactWithDetail(int id)
        {
            if(id == 0)
            {
                return BadRequest("Incorrect id");
            }

            return Ok(await _context.Contacts.Where(el => el.Id == id).FirstOrDefaultAsync());
        }

        // GET /contact/category
        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        // GET /contact/subcategory/{idCategory}
        [HttpGet("subcategory/category/{idCategory}")]
        public async Task<ActionResult<IEnumerable<Subcategory>>> GetSubcategories(int idCategory)
        {
            if (idCategory == 0)
            {
                return BadRequest("Incorrect id");
            }
            return Ok(await _context.Subcategories.Where(e => e.CategoryId == idCategory).ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            if (id == 0)
            {
                return BadRequest("Incorrect id");
            }

            var contact = await _context.Contacts.Where(el => el.Id == id).FirstOrDefaultAsync();
            if (contact == null)
            {
                return BadRequest("Contact not found");
            }
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult> AddContact(Contact contact)
        {
            // is there a contact for such an email
            Contact existingContact = await _context.Contacts.Where(el => el.Email == contact.Email).FirstOrDefaultAsync();
            if (existingContact != null)
            {
                return BadRequest("This email already exists");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var con = await _context.Contacts.Where(el => el.Id == contact.Id).FirstOrDefaultAsync();
            if (con == null)
            {
                return BadRequest();
            }         
            con.Name = contact.Name;
            con.Surname = contact.Surname;
            con.Email = contact.Email;
            con.Password = contact.Password;
            con.Phone = contact.Phone;
            con.BirthDate = contact.BirthDate;
            con.SubcategoryOther = contact.SubcategoryOther;
            con.CategoryID = contact.CategoryID;
            con.SubcategoryID = contact.SubcategoryID;

            _context.Contacts.Update(con);
            await _context.SaveChangesAsync();

            return Ok(con);
        }
    }
}