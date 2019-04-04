using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BigriverBookstore_api.Data.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        public string Nationality { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
