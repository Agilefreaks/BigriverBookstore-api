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
        self_view = 'books.get'
        self_view_kwargs = {'id': '<id>'}
        self_view_many = 'books.get_all'
