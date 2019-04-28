from . import Repository
from api.schemas import jsonify_schema_dump


class InMemoryAuthorsRepository(Repository):
    """ This implementation deals with in-memory data
    storage.
    """

    def __init__(self, db_context, schema):
        self.__db_context = db_context
        self.__schema = schema

    def get(self, id):
        author = self.__db_context['authors'][id - 1]
        data = self.__schema().dump(author).data
        return jsonify_schema_dump(data)

    def get_all(self):
        authors = self.__db_context['authors']
        data = self.__schema(many=True).dump(authors).data
        return jsonify_schema_dump(data)
