import unittest
from api import create_app
from api.mock_db import db

# Big TODO


class TestCase(unittest.TestCase):
    def setUp(self):
        self.app = create_app().test_client()

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
