using Xunit;
using BigriverBookstore_api.Data;
using BigriverBookstore_api.Data.Entities;
using BigriverBookstore_api.Services;
using BigriverBookstore_api;
using Moq;
using System;
using System.Linq;
using AutoMapper;

namespace BigriverBookstore_api_tests
{
    [Collection("WebHostCollection")]
    public class BookServiceTests
    {
        private RepositoryWrapper _repository;
        private IMapper _mapper;
        private BookResourceService _service;
        
        private void Initialize()
        {
            _repository = new Mock<RepositoryWrapper>().Object;
            _repository.Books.ClearAll();
            var config = new MapperConfiguration(opts =>
            {
                // Add your mapper profile configs or mappings here
                opts.AddProfile(new MappingProfile());
            });

            _mapper = config.CreateMapper();
            _service = new BookResourceService(_repository, _mapper);
        }

        [Fact]
        public void Can_Get_Books()
        {
            // arrange
            this.Initialize();

            _repository.Books.Add(new Book { Date_Published = DateTime.Now, Id = 3, ISBN = "312", Title = "Test" });

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

            _repository.Books.Add(new Book { Date_Published = DateTime.Now, Id = 3, ISBN = "312", Title = "Test" });

            // act
            var result = _service.GetAsync(3);

            // assert
            Assert.True(result.Result.Id == 3);
        }

        [Fact]
        public void Can_Get_Book_By_Id_Nonexistent()
        {
            // arrange
            this.Initialize();

            _repository.Books.Add(new Book { Date_Published = DateTime.Now, Id = 3, ISBN = "312", Title = "Test" });

            // act
            var result = _service.GetAsync(4);

            // assert
            Assert.True(result.IsFaulted);
            Assert.True(result.Exception.InnerExceptions.Count == 1);
        }

        [Fact]
        public void Can_Get_Books_Blank_Repository()
        {
            // arrange
            this.Initialize();

            // act
            var result = _service.GetAsync();

            // assert
            Assert.True((result.Result).ToList().Count == 0);
            Assert.True(result.Exception == null);
        }
    }
}
