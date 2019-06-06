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
                .SetApiCollectionPathSegment("book");
            
            this.ResourceIdentity(x => x.BookId)
                .SetApiType("books");

            this.Attribute(x => x.Title)
                .SetApiPropertyName("book-title");

            this.Attribute(x => x.DatePublished)
                .SetApiPropertyName("date-published");

            this.Attribute(x => x.ISBN)
                .SetApiPropertyName("isbn");
        }
    }
}