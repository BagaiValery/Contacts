﻿namespace Contacts.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Contact> Contacts { get; set;}
    }
}
