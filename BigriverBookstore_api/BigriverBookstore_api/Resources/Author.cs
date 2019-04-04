using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
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

        [HasOne("book")]
        public virtual Book Book { get; set; }

        public int BookId { get; set; }
    }
}
