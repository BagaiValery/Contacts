using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [DisplayName("Name")]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Mobile Phone")]
        [Column(TypeName = "decimal")]
        public decimal MobilePhone { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Job")]
        [Column(TypeName = "int")]
        public int JobId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Birthday Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
    }
}
