using JsonApiFramework.JsonApi;

namespace BigriverBookstore_api.WebService.Controllers
{
    public interface IBookToPhotosController
    {
        Document GetBookToPhotos(long id);
    }
}