import unittest
from api import create_app

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


if __name__ == '__main__':
    unittest.main()
