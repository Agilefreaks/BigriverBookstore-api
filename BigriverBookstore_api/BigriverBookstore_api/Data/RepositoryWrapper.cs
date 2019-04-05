using BigriverBookstore_api.Data.Repositories;
using BigriverBookstore_api.Data.Entities;
using System;

namespace BigriverBookstore_api.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IBookRepository _book;
        private IAuthorRepository _author;


        public IBookRepository BookRepository
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository();
                    this.AddFakeBookData();
                }

                return _book;
            }

            set
            {
                _book = value;
            }
        }

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_author == null)
                {
                    _author = new AuthorRepository();
                    this.AddFakeAuthorData();
                }

                return _author;
            }

            set
            {
                _author = value;
            }
        }

        private void AddFakeBookData()
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

        private void AddFakeAuthorData()
        {
            this._author.Add(new Author
            {
                Id = 1,
                FirstName = "FN1",
                LastName = "LN1",
                DateOfBirth = DateTime.Now,
                Nationality = "Romanian"
            });
            this._author.Add(new Author
            {
                Id = 2,
                FirstName = "FN2",
                LastName = "LN2",
                DateOfBirth = DateTime.Now,
                Nationality = "Romanian"
            });
            this._author.Add(new Author
            {
                Id = 3,
                FirstName = "FN3",
                LastName = "LN3",
                DateOfBirth = DateTime.Now,
                Nationality = "Romanian"
            });
            this._author.Add(new Author
            {
                Id = 4,
                FirstName = "FN4",
                LastName = "LN4",
                DateOfBirth = DateTime.Now,
                Nationality = "Romanian"
            });
            this._author.Add(new Author
            {
                Id = 5,
                FirstName = "FN5",
                LastName = "LN5",
                DateOfBirth = DateTime.Now,
                Nationality = "Romanian"
            });
        }
    }
}