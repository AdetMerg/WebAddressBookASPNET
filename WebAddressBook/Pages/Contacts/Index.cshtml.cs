using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddressContactsBook.Models;
using WebAddressBook.Data;

namespace WebAddressBook.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly WebAddressBook.Data.WebAddressBookContactContext _context;

        public IndexModel(WebAddressBook.Data.WebAddressBookContactContext context)
        {
            _context = context;
        }

        public IList<Contact> Contact { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var contacts = from m in _context.Contact
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                contacts = contacts.Where(s => s.FirstName.Contains(SearchString) ||
                                               s.LastName.Contains(SearchString) ||
                                               s.SecondName.Contains(SearchString) ||
                                               s.SecondName.Contains(SearchString) ||
                                               s.Birthday.Contains(SearchString) ||
                                               s.CompanyName.Contains(SearchString) ||
                                               s.SkypeName.Contains(SearchString) ||
                                               s.MailboxName.Contains(SearchString) ||
                                               s.PhoneNumber.Contains(SearchString) ||
                                               s.Comments.Contains(SearchString));
            }

            Contact = await contacts.ToListAsync();

            //Contact = await _context.Contact.ToListAsync();
        }
    }
}
