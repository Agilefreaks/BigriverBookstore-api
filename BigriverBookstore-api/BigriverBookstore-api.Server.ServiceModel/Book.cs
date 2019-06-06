using System;

namespace BigriverBookstore_api.ServiceModel
{
    public class Book
    {
        public long BookId { get; set; }
        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
        public string ISBN { get; set; }
    }
}