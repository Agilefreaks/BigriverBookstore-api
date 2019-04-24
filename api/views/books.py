from flask import Blueprint
from api.mock_db import db
from api.schemas.book import BookSchema
from . import jsonify_schema_dump

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
