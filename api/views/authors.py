from flask import Blueprint
from api.mock_db import db
from api.schemas.author import AuthorSchema
from . import jsonify_schema_dump

authors_bp = Blueprint('authors', __name__)


@authors_bp.route('/')
def get_all():
    authors = db['authors']
    data = AuthorSchema(many=True).dump(authors).data
    return jsonify_schema_dump(data)
