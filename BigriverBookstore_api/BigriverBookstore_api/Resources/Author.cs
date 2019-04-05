using System;
using System.Collections.Generic;
using JsonApiDotNetCore.Models;

namespace BigriverBookstore_api.Resources
{
    public class Author : Identifiable
    {
        [Attr("firstName")]
        public string FirstName { get; set; }

        [Attr("lastName")]
        public string LastName { get; set; }

        [Attr("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Attr("nationality")]
        public string Nationality { get; set; }

        [HasMany("books")]
        public virtual List<Book> Books { get; set; }
    }
}
