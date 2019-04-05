using BigriverBookstore_api.Data.Repositories;
using BigriverBookstore_api.Data.Entities;
using System;
using System.Collections.Generic;

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
            for (int i = 1; i <= 5; i++)
            {
                var book = this.GetBook(i);
                book.Author = GetAuthor(i);
                _book.Add(book);
            }
        }

        private void AddFakeAuthorData()
        {
            for (int i = 1; i <= 5; i++)
            {
                var author = GetAuthor(i);
                _author.Add(author);
            }
        }

        private Book GetBook(int id)
        {
            return new Book
            {
                Id = id,
                Title = "My Book" + id.ToString(),
                ISBN = "978-3-16-148410-" + id.ToString(),
                Date_Published = new DateTime(2019, 04, 01),
                AuthorId = id
            };
        }

        private Author GetAuthor(int id)
        {
            return new Author
            {
                Id = id,
                FirstName = "FN" + id.ToString(),
                LastName = "LN" + id.ToString(),
                DateOfBirth = DateTime.Now,
                Nationality = "Romanian",
                Books = new List<Book> { GetBook(id) }
            };
        }
    }
}