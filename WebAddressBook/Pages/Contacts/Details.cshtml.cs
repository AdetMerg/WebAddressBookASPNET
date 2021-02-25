using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AddressContactsBook.Models;
using WebAddressBook.Data;

namespace WebAddressBook.Pages.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly WebAddressBook.Data.WebAddressBookContactContext _context;

        public DetailsModel(WebAddressBook.Data.WebAddressBookContactContext context)
        {
            _context = context;
        }

        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact = await _context.Contact.FirstOrDefaultAsync(m => m.ID == id);

            if (Contact == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
