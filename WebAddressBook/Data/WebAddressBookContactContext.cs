using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AddressContactsBook.Models;

namespace WebAddressBook.Data
{
    public class WebAddressBookContactContext : DbContext
    {
        public WebAddressBookContactContext (DbContextOptions<WebAddressBookContactContext> options)
            : base(options)
        {
        }

        public DbSet<AddressContactsBook.Models.Contact> Contact { get; set; }
    }
}
