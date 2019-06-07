using BigriverBookstore_api.ServiceModel;
using JsonApiFramework.ServiceModel.Configuration;

namespace BigriverBookstore_api.WebService.Configurations
{
    public class AuthorConfiguration : ResourceTypeBuilder<Author>
    {
        public AuthorConfiguration()
        {
            this.Hypermedia()
                .SetApiCollectionPathSegment("authors");

            this.ResourceIdentity(x => x.AuthorId)
                .SetApiType("author");
            
            this.Attribute(x => x.FirstName)
                .SetApiPropertyName("firstName");
            
            this.Attribute(x => x.LastName)
                .SetApiPropertyName("lastName");
            
            this.ToManyRelationship<Book>("books");
        }
    }
}