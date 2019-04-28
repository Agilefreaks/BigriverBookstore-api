from marshmallow_jsonapi import fields
from marshmallow_jsonapi.flask import Schema


class AuthorSchema(Schema):
    id = fields.Str()
    first_name = fields.Str()
    last_name = fields.Str()
    date_of_birth = fields.Date()
    nationality = fields.Str()

    class Meta:
        type_ = 'authors'
        strict = True
        self_view = 'authors.get'
        self_view_kwargs = {'id': '<id>'}
        self_view_many = 'authors.get_all'
