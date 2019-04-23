from flask import Blueprint, jsonify
from .models import Book
from .schemas import BookSchema
from .mock_db import db


def jsonify_schema_dump(*args, **kwargs):
    """Wrapper around jsonify that sets the Content-Type of the response to
    application/vnd.api+json.
    """
    response = jsonify(*args, **kwargs)
    response.mimetype = 'application/vnd.api+json'
    return response


books_bp = Blueprint('books', __name__)


@books_bp.route('/')
def get_all():
    books = db['books']
    data = BookSchema(many=True).dump(books).data
    return jsonify_schema_dump(data)


@books_bp.route('/<int:book_id>')
def get_by_id(book_id):
    book = db['books'][book_id - 1]
    data = BookSchema().dump(book).data
    return jsonify_schema_dump(data)
