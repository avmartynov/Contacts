﻿namespace Contacts.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string Name { get; set; } = default!;

        public string? Phone { get; set; } 
    }
}