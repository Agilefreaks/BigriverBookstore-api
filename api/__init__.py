from flask import Flask
from api.views.books import BooksApi
from api.views.authors import AuthorsApi


class FlaskAppFactory:
    def __init__(self, books_repo, authors_repo):
        self.__books_repo = books_repo
        self.__authors_repo = authors_repo

    def create(self):
        app = Flask(__name__)
        BooksApi.repository = self.__books_repo
        AuthorsApi.repository = self.__authors_repo
        app.register_blueprint(BooksApi.blueprint, url_prefix='/books')
        app.register_blueprint(AuthorsApi.blueprint, url_prefix='/authors')
        return app
