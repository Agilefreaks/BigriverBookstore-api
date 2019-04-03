using BigriverBookstore_api.Data.Repositories;
using BigriverBookstore_api.Data.Entities;
using System;

namespace BigriverBookstore_api.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IBookRepository _book;
        

        public IBookRepository Books
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository();
                    this.AddFakeData();
                }

                return _book;
            }

            set
            {
                _book = value;
            }
        }

        private void AddFakeData()
        {
            this._book.Add(new Book
            {
                Id = 1,
                Title = "My Book1",
                ISBN = "978-3-16-148410-1",
                Date_Published = new DateTime(2019, 04, 01)
            });
            this._book.Add(new Book
            {
                Id = 2,
                Title = "My Book2",
                ISBN = "978-3-16-148410-2",
                Date_Published = new DateTime(2019, 04, 01)
            });
            this._book.Add(new Book
            {
                Id = 3,
                Title = "My Book3",
                ISBN = "978-3-16-148410-3",
                Date_Published = new DateTime(2019, 04, 01)
            });
            this._book.Add(new Book
            {
                Id = 4,
                Title = "My Book4",
                ISBN = "978-3-16-148410-4",
                Date_Published = new DateTime(2019, 04, 01)
            });
            this._book.Add(new Book
            {
                Id = 5,
                Title = "My Book5",
                ISBN = "978-3-16-148410-5",
                Date_Published = new DateTime(2019, 04, 01)
            });
        }
    }
}