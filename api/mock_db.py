import datetime as dt
from .models import Book

book1 = Book(id='1', title='Test title 1', date_published=dt.date(
    1990, 6, 12), isbn='0-3605-3454-6')
book2 = Book(id='2', title='Test title 2', date_published=dt.date(
    1993, 3, 21), isbn='0-6388-0530-9')

db = {
    'books': [
        book1,
        book2
    ]
}
