class Model:
    def __init__(self, **kwargs):
        for key, val in kwargs.items():
            setattr(self, key, val)


class Book(Model):
    pass


class Author(Model):
    pass
