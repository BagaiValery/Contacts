using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string JobName { get; set; }
        public List<Contact> Contacts { get; set;}
    }
}
