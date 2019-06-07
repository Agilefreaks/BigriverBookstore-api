using JsonApiFramework.JsonApi;

namespace BigriverBookstore_api.WebService.Controllers
{
    public interface IApiEntryPointController
    {
        Document Get();
    }
}