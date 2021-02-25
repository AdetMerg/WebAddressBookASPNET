using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AddressContactsBook.Models
{
    /**
     * This is the base model class to handle the contact data info
     */
    public class Contact
    {
        public int ID { get; set; }

        [Display ( Name = "Имя")]
        [DataType ( DataType.Text)]
        [StringLength(30)]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string SecondName { get; set; }
        [Display(Name = "Отчество")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string LastName { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public string Birthday { get; set; }

        [Display(Name = "Организация")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string CompanyName { get; set; }

        [Display ( Name = "Skype name")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string SkypeName { get; set; }
        [Display ( Name = "E-mail")]
        [DataType ( DataType.Text)]
        [StringLength(30)]
        public string MailboxName { get; set; }
        [Display ( Name = "Телефон")]
        [DataType ( DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Другое")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Comments { get; set; }

    }
}
