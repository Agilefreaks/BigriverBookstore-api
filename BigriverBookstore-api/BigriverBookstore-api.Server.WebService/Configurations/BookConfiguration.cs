using System;
using BigriverBookstore_api.ServiceModel;
using JsonApiFramework.ServiceModel.Configuration;

namespace BigriverBookstore_api.WebService.Configurations
{
    public class BookConfiguration : ResourceTypeBuilder<Book>
    {
        public BookConfiguration()
        {
            this.Hypermedia()
                .SetApiCollectionPathSegment("books");
            
            this.ResourceIdentity(x => x.BookId)
                .SetApiType("books");

            this.Attribute(x => x.Title)
                .SetApiPropertyName("bookTitle");

            this.Attribute(x => x.DatePublished)
                .SetApiPropertyName("datePublished");

            this.Attribute(x => x.ISBN)
                .SetApiPropertyName("isbn");
            
        }
    }
}