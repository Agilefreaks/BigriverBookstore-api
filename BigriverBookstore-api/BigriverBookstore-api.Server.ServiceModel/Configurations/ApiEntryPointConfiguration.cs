using System;
using JsonApiFramework.ServiceModel.Configuration;

namespace BigriverBookstore_api.ServiceModel.Configurations
{
    public class ApiEntryPointConfiguration : ResourceTypeBuilder<ApiEntryPoint>
    {
        public ApiEntryPointConfiguration()
        {
            this.Hypermedia().SetApiCollectionPathSegment(String.Empty);

            this.ResourceIdentity()
                .SetApiType("api-entry-point");
        }
    }
}