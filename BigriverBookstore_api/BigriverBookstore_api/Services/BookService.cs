using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonApiDotNetCore.Services;
using BigriverBookstore_api.Models;
using JsonApiDotNetCore.Models;

namespace BigriverBookstore_api.Services
{
    public class BookService : IResourceService<Book>
    {
        public Task<Book> CreateAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetAsync(int id)
        {
            var task = new Task<Book>(() => this.GetOne(id));

            task.RunSynchronously(TaskScheduler.Default);

            return task;
        }

        public Task<object> GetRelationshipAsync(int id, string relationshipName)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetRelationshipsAsync(int id, string relationshipName)
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateAsync(int id, Book entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRelationshipsAsync(int id, string relationshipName, List<ResourceObject> relationships)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAsync()
        {
            var task = new Task<IEnumerable<Book>>(() => this.GetAll());

            task.RunSynchronously(TaskScheduler.Default);

            return task;
        }

        private IEnumerable<Book> GetAll()
        {
            return this.GetFakeBookList();
        }

        private Book GetOne(int id)
        {
            return this.GetFakeBookList().FirstOrDefault(b => b.Id == id);
        }

        private IEnumerable<Book> GetFakeBookList()
        {
            return new List<Book> {
                new Book {
                    Id=1,
                    Title = "My Book1",
                    ISBN = "978-3-16-148410-1",
                    Date_Published = new DateTime(2019,04,01)
                },
                new Book {
                    Id=2,
                    Title = "My Book2",
                    ISBN = "978-3-16-148410-2",
                    Date_Published = new DateTime(2019,04,01)
                },
                new Book {
                    Id=3,
                    Title = "My Book3",
                    ISBN = "978-3-16-148410-3",
                    Date_Published = new DateTime(2019,04,01)
                },
                new Book {
                    Id=4,
                    Title = "My Book4",
                    ISBN = "978-3-16-148410-4",
                    Date_Published = new DateTime(2019,04,01)
                },
                new Book {
                    Id=5,
                    Title = "My Book5",
                    ISBN = "978-3-16-148410-5",
                    Date_Published = new DateTime(2019,04,01)
                },
            };
        }
    }
}
