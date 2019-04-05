using Xunit;
using BigriverBookstore_api.Data;
using BigriverBookstore_api.Data.Entities;
using BigriverBookstore_api.Services;
using BigriverBookstore_api;
using Moq;
using System;
using System.Linq;
using AutoMapper;
using BigriverBookstore_api.Data.Repositories;
using System.Collections.Generic;

namespace BigriverBookstore_api_tests
{
    [Collection("WebHostCollection")]
    public class BookServiceTests
    {
        private IMapper _mapper;
        private BookResourceService _service;
        private Mock<IBookRepository> _bookRepositoryMock = new Mock<IBookRepository>();

        private void Initialize()
        {
            var contextMock = new Mock<IRepositoryWrapper>();
            contextMock.SetupGet(c => c.BookRepository).Returns(_bookRepositoryMock.Object);

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MappingProfile());
            });

            _mapper = config.CreateMapper();
            _service = new BookResourceService(contextMock.Object, _mapper);
        }

        [Fact]
        public void Can_Get_Books()
        {
            // arrange
            this.Initialize();
            _bookRepositoryMock.Setup(r=>r.GetAllEntities()).Returns(new List<Book> { new Book { Date_Published = DateTime.Now, Id = 3, ISBN = "312", Title = "Test" } });

            // act
            var result = _service.GetAsync();
            var bookList = (result.Result).ToList();

            // assert
            Assert.True(bookList.Count == 1);
            Assert.True(bookList.FirstOrDefault().Id == 3);
        }

        [Fact]
        public void Can_Get_Book_By_Id()
        {
            // arrange
            this.Initialize();
            _bookRepositoryMock.Setup(r => r.GetById(3)).Returns(new Book { Date_Published = DateTime.Now, Id = 3, ISBN = "312", Title = "Test" });

            // act
            var result = _service.GetAsync(3);
            var book = result.Result;

            // assert
            Assert.True(book.Id == 3);
        }

        [Fact]
        public void Can_Get_Book_By_Id_Nonexistent()
        {
            //arrange
            Initialize();
            _bookRepositoryMock.Setup(r => r.GetById(3)).Returns(new Book { Date_Published = DateTime.Now, Id = 3, ISBN = "312", Title = "Test" });

            //act
            var result = _service.GetAsync(4);

            //assert
            Assert.True(result.Result == null);
        }

        [Fact]
        public void Can_Get_Books_Blank_Repository()
        {
            // arrange
            this.Initialize();
            _bookRepositoryMock.Setup(r => r.GetAllEntities()).Returns(new List<Book>());

            // act
            var result = _service.GetAsync();
            var bookList = (result.Result).ToList();

            // assert
            Assert.True((result.Result).ToList().Count == 0);
        }
    }
}
