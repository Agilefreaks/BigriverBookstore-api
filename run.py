from api import FlaskAppFactory
from api.repositories.books_repository import InMemoryBooksRepository
from api.repositories.authors_repository import InMemoryAuthorsRepository
from api.mock_db import db
from api.schemas.book import BookSchema
from api.schemas.author import AuthorSchema

if __name__ == '__main__':
    FlaskAppFactory(InMemoryBooksRepository(db, BookSchema),
                    InMemoryAuthorsRepository(db, AuthorSchema)).create().run(debug=True)
