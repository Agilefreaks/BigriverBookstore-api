from . import Repository
from api.schemas import jsonify_schema_dump


class InMemoryBooksRepository(Repository):
    """ This implementation deals with in-memory data
    storage.
    """

    def __init__(self, db_context, schema):
        self.__db_context = db_context
        self.__schema = schema

    def get(self, id):
        book = self.__db_context['books'][id - 1]
        data = self.__schema().dump(book).data
        return jsonify_schema_dump(data)

    def get_all(self):
        books = self.__db_context['books']
        data = self.__schema(many=True).dump(books).data
        return jsonify_schema_dump(data)
