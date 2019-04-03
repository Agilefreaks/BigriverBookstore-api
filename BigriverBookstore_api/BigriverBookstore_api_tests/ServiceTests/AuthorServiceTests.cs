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
    public class AuthorServiceTests
    {
        private RepositoryWrapper _context;
        private IMapper _mapper;
        private AuthorResourceService _service;
        
        private void Initialize()
        {
            _context = new Mock<RepositoryWrapper>().Object;
            _context.AuthorRepository.ClearAll();
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MappingProfile());
            });

            _mapper = config.CreateMapper();
            _service = new AuthorResourceService(_context, _mapper);
        }

        [Fact]
        public void Can_Get_Authors()
        {
            // arrange
            this.Initialize();

            _context.AuthorRepository.Add(new Author { Id = 3, DateOfBirth = DateTime.Now, FirstName = "FN3", LastName = "LN3", Nationality = "Turc" });

            // act
            var result = _service.GetAsync();
            var bookList = (result.Result).ToList();

            // assert
            Assert.True(bookList.Count == 1);
            Assert.True(bookList.FirstOrDefault().Id == 3);
        }

        [Fact]
        public void Can_Get_Author_By_Id()
        {
            // arrange
            this.Initialize();

            _context.AuthorRepository.Add(new Author { Id = 3, DateOfBirth = DateTime.Now, FirstName = "FN3", LastName = "LN3", Nationality = "Turc" });

            // act
            var result = _service.GetAsync(3);

            // assert
            Assert.True(result.Result.Id == 3);
        }

        [Fact]
        public void Can_Get_Author_By_Id_Nonexistent()
        {
            // arrange
            this.Initialize();

            _context.AuthorRepository.Add(new Author { Id = 3, DateOfBirth = DateTime.Now, FirstName = "FN3", LastName = "LN3", Nationality = "Turc" });

            // act
            var result = _service.GetAsync(4);

            // assert
            Assert.True(result.IsFaulted);
            Assert.True(result.Exception.InnerExceptions.Count == 1);
        }

        [Fact]
        public void Can_Get_Authors_Blank_Repository()
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
