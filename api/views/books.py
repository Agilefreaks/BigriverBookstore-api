from flask import Blueprint


class BooksApi:
    blueprint = Blueprint('books', __name__)
    repository = None

    @staticmethod   
    @blueprint.route('/')
    def get_all():
        return BooksApi.repository.get_all()

    @staticmethod
    @blueprint.route('/<int:id>')
    def get(id):
        return BooksApi.repository.get(id)
