using BigriverBookstore_api.ServiceModel.Configurations;

using JsonApiFramework.Conventions;
using JsonApiFramework.ServiceModel;
using JsonApiFramework.ServiceModel.Configuration;

namespace BigriverBookstore_api.ServiceModel
{
    public static class ConfigurationFactory
    {
        public static IConventions CreateConventions()
        {
            var conventionsBuilder = new ConventionsBuilder();

            conventionsBuilder.ApiAttributeNamingConventions()
                .AddStandardMemberNamingConvention();

            conventionsBuilder.ApiTypeNamingConventions()
                .AddPluralNamingConvention()
                .AddStandardMemberNamingConvention();

            conventionsBuilder.ResourceTypeConventions()
                .AddPropertyDiscoveryConvention();

            var conventions = conventionsBuilder.Create();
            return conventions;
        }

        public static IServiceModel CreateServiceModel()
        {
            var serviceModelBuilder = new ServiceModelBuilder();

            serviceModelBuilder.Configurations.Add(new ApiEntryPointConfiguration());

            serviceModelBuilder.HomeResource<ApiEntryPoint>();

            var conventions = CreateConventions();
            var serviceModel = serviceModelBuilder.Create(conventions);
            return serviceModel;
        }
    }
}