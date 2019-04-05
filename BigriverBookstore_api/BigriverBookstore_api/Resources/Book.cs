using System;
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

        public int AuthorId { get; set; }

        [HasOne("author")]
        public virtual Author Author { get; set; }
    }
}
