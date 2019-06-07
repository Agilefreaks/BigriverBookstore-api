using BigriverBookstore_api.ServiceModel;
using JsonApiFramework.ServiceModel.Configuration;

namespace BigriverBookstore_api.WebService.Configurations
{
    public class PhotoConfiguration : ResourceTypeBuilder<Photo>
    {
        public PhotoConfiguration()
        {
            this.Attribute(x => x.BookId).Ignore();

            this.ToOneRelationship<Book>("books");
        }
    }
}