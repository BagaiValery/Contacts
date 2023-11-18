namespace Contacts.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MobilePhone { get; set; }
        public int? JobId { get; set; }
        public DateTime BirthDate { get; set; }
        public Job? Job { get; set; }
    }
}
