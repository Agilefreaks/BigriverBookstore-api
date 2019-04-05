using System;
using System.Collections.Generic;

namespace BigriverBookstore_api.Data.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        public string Nationality { get; set; }

        public List<Book> Books { get; set; }
    }
}
