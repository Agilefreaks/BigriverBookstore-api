from flask import Blueprint


class AuthorsApi:
    blueprint = Blueprint('authors', __name__)
    repository = None

    @staticmethod
    @blueprint.route('/')
    def get_all():
        return AuthorsApi.repository.get_all()

    @staticmethod
    @blueprint.route('/<int:id>')
    def get(id):
        return AuthorsApi.repository.get(id)
