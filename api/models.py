from uuid import uuid4
from marshmallow_jsonapi import fields
from marshmallow_jsonapi.flask import Schema


class Model:
    def __init__(self, **kwargs):
        for key, val in kwargs.items():
            setattr(self, key, val)


class Book(Model):
    pass


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
