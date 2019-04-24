from flask import Flask
from api.views.authors import authors_bp
from api.views.books import books_bp


def create_app():
    app = Flask(__name__)
    app.register_blueprint(books_bp, url_prefix='/books')
    app.register_blueprint(authors_bp, url_prefix='/authors')
    return app
