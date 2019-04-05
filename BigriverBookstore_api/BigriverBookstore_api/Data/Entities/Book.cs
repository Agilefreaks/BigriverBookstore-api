using System;

namespace BigriverBookstore_api.Data.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        
        public DateTime Date_Published { get; set; }
        
        public string ISBN { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int PhotoId { get; set; }

        public Photo Photo { get; set; }
    }
}
