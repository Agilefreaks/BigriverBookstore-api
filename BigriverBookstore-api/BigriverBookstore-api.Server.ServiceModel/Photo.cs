using System;

namespace BigriverBookstore_api.ServiceModel
{
    public class Photo
    {
        public long PhotoId { get; set; }
        public long BookId { get; set; }
        
        public Uri PhotoUri { get; set; }
    }
}