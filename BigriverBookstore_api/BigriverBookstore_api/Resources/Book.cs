using System;
using System.Collections.Generic;
using JsonApiDotNetCore.Models;

namespace BigriverBookstore_api.Resources
{
    public class Book : Identifiable
    {
        [Attr("title")]
        public string Title { get; set; }

        [Attr("date_published")]
        public DateTime Date_Published { get; set; }

        [Attr("isbn")]
        public string ISBN { get; set; }

        [HasOne("author")]
        public virtual Author Author { get; set; }

        [HasOne("photo")]
        public virtual Photo Photo { get; set; }
    }
}
