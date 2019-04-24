import datetime as dt
from .models import Book, Author

book1 = Book(id='1', title='Test title 1', date_published=dt.date(
    1990, 6, 12), isbn='0-3605-3454-6')
book2 = Book(id='2', title='Test title 2', date_published=dt.date(
    1993, 3, 21), isbn='0-6388-0530-9')

author1 = Author(id='1', first_name='John', last_name='Doe',
                 date_of_birth=dt.date(1980, 3, 12), nationality='Chinese')
author2 = Author(id='2', first_name='Xin', last_name='Phu',
                 date_of_birth=dt.date(1970, 2, 14), nationality='English')

db = {
    'books': [
        book1,
        book2
    ],
    'authors': [
        author1,
        author2
    ]
}
