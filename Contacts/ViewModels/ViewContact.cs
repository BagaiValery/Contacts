using Contacts.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contacts.ViewModels
{
    public class ViewContact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Mobile Phone")]
        public decimal MobilePhone { get; set; }

        [DisplayName("Job")]
        public int? JobId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Birthday Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }
    }

    public static class ViewContactExtensions
    {
        public static Contact ToContact(this ViewContact contact)
        {
            return new Contact
            {
                Id = contact.Id,
                Name = contact.Name,
                MobilePhone = contact.MobilePhone,
                JobId = contact.JobId,
                BirthDate = contact.BirthDate
            };
        }
    }
}
