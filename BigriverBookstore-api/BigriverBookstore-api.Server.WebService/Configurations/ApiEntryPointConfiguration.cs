using System;
using JsonApiFramework.ServiceModel.Configuration;

namespace BigriverBookstore_api.ServiceModel.Configurations
{
    public class ApiEntryPointConfiguration : ResourceTypeBuilder<ApiEntryPoint>
    {
        public ApiEntryPointConfiguration()
        {
            Hypermedia().SetApiCollectionPathSegment(String.Empty);

            ResourceIdentity()
                .SetApiType("api-entry-point");
        }
    }
}