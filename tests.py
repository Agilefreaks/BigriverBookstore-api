import unittest
from api import FlaskAppFactory
from api.repositories.books_repository import InMemoryBooksRepository
from api.repositories.authors_repository import InMemoryAuthorsRepository
from api.mock_db import db
from api.schemas.book import BookSchema
from api.schemas.author import AuthorSchema

# UPDATE I can now plug in different repository implementations and their respective db contexts.
# TODO Creating mock repositories and DB contexts to test the app.


class TestCase(unittest.TestCase):
    def setUp(self):
        self.app = FlaskAppFactory(InMemoryBooksRepository(db, BookSchema),
                                   InMemoryAuthorsRepository(db, AuthorSchema)).create().test_client()

    def tearDown(self):
        pass

    def test_all_books_api_response(self):
        response = self.app.get('/books/')
        self.assertEqual(response.status_code, 200)

    def test_all_books_api_mimetype(self):
        response = self.app.get('/books/')
        self.assertTrue(response.mimetype == 'application/vnd.api+json')

    def test_all_authors_api_successful(self):
        response = self.app.get('/authors/')
        self.assertEqual(response.status_code, 200)

    def test_all_authors_api_mimetype(self):
        response = self.app.get('/authors/')
        self.assertTrue(response.mimetype == 'application/vnd.api+json')

    def test_all_authors_api_content(self):
        response = self.app.get('/authors/')
        self.assertTrue(response.json['data'][1]['attributes']
                        ['first_name'] == db['authors'][1].first_name)


if __name__ == '__main__':
    unittest.main()
