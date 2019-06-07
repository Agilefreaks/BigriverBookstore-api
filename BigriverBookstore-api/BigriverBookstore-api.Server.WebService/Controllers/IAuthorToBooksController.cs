using JsonApiFramework.JsonApi;

namespace BigriverBookstore_api.WebService.Controllers
{
    public interface IAuthorToBooksController
    {
        Document GetAuthorToBooks(long id);
    }
}