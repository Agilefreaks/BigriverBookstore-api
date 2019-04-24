from marshmallow_jsonapi import fields
from marshmallow_jsonapi.flask import Schema


class BookSchema(Schema):
    id = fields.Str()
    title = fields.Str()
    date_published = fields.Date()
    isbn = fields.Str()

    class Meta:
        type_ = 'books'
        strict = True
        self_view = 'books.get_by_id'
        self_view_kwargs = {'book_id': '<id>'}
        self_view_many = 'books.get_all'


class AuthorSchema(Schema):
    id = fields.Str()
    first_name = fields.Str()
    last_name = fields.Str()
    date_of_birth = fields.Date()
    nationality = fields.Str()

    class Meta:
        type_ = 'authors'
        strict = True
        self_view_many = 'authors.get_all'
