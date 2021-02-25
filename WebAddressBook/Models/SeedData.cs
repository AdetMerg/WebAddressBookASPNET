using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAddressBook.Data;

namespace WebAddressBook.Models
{
    /**
     * Class used for filling the database with the 
     * sample contact data
     */
    public class SeedData
    {

        List<String> FirstNameList;
        List<String> SecondNameList;
        List<String> LastNameList;
        List<String> CompanyNameList;

        private void PopulateFirstNameList()
        {
            FirstNameList = new List<string>();
            FirstNameList.Add("Андрей");
            FirstNameList.Add("Александр");
            FirstNameList.Add("Михаил");
            FirstNameList.Add("Евгений");
            FirstNameList.Add("Юрий");
            FirstNameList.Add("Олег");
            FirstNameList.Add("Игорь");
        }

        private void PopulateSecondNameList()
        {
            SecondNameList = new List<string>();
            SecondNameList.Add("Иванов");
            SecondNameList.Add("Петров");
            SecondNameList.Add("Сидоров");
            SecondNameList.Add("Свиридов");
            SecondNameList.Add("Машковцев");
        }

        private void PopulateLastNameList()
        {
            LastNameList = new List<string>();
            LastNameList.Add("Иванович");
            LastNameList.Add("Александрович");
            LastNameList.Add("Михайлович");
            LastNameList.Add("Андреевич");
            LastNameList.Add("Сергеевич");
        }

        private void PopulateCompanyNameList()
        {
            CompanyNameList = new List<string>();
            CompanyNameList.Add("Мечел");
            CompanyNameList.Add("Вектор");
            CompanyNameList.Add("ПРОГРЕСС");
            CompanyNameList.Add("СпецТехнологии");
            CompanyNameList.Add("Машстрой");
        }

        public void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebAddressBookContactContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebAddressBookContactContext>>()))
            {
                // Look for any movies.
                if (context.Contact.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateFirstNameList();
                PopulateSecondNameList();
                PopulateLastNameList();
                PopulateCompanyNameList();


                for (int i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    AddressContactsBook.Models.Contact currContact = new AddressContactsBook.Models.Contact();

                    int firstNameInd = r.Next(0, FirstNameList.Count - 1);
                    int secondNameInd = r.Next(0, SecondNameList.Count - 1);
                    int lastNameInd = r.Next(0, LastNameList.Count - 1);
                    int companyNameInd = r.Next(0, CompanyNameList.Count - 1);

                    currContact.FirstName = FirstNameList[firstNameInd];
                    currContact.SecondName = SecondNameList[secondNameInd];
                    currContact.LastName = LastNameList[lastNameInd];
                    currContact.CompanyName = CompanyNameList[companyNameInd];

                    context.Contact.Add(currContact);
                }

                context.SaveChanges();
            }
        }
    }
}
