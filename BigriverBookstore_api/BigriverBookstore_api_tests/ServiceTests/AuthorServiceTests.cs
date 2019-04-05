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
    public class AuthorServiceTests
    {
        private IMapper _mapper;
        private AuthorResourceService _service;
        private Mock<IAuthorRepository> _authorRepositoryMock = new Mock<IAuthorRepository>();
        
        private void Initialize()
        {
            var contextMock = new Mock<IRepositoryWrapper>();
            contextMock.SetupGet(c => c.AuthorRepository).Returns(_authorRepositoryMock.Object);

            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new MappingProfile());
            });

            _mapper = config.CreateMapper();
            _service = new AuthorResourceService(contextMock.Object, _mapper);
        }

        [Fact]
        public void Can_Get_Authors()
        {
            // arrange
            Initialize();
            _authorRepositoryMock.Setup(r => r.GetAllEntities()).Returns(new List<Author> { new Author { Id = 3, DateOfBirth = DateTime.Now, FirstName = "FN3", LastName = "LN3", Nationality = "Turc" } });

            // act
            var result = _service.GetAsync();
            var authors = (result.Result).ToList();

            // assert
            Assert.True(authors.Count == 1);
            Assert.True(authors.FirstOrDefault().Id == 3);
        }

        [Fact]
        public void Can_Get_Author_By_Id()
        {
            //arrange
            Initialize();
            _authorRepositoryMock.Setup(r => r.GetById(3)).Returns(new Author { Id = 3, DateOfBirth = DateTime.Now, FirstName = "FN3", LastName = "LN3", Nationality = "Turc" });

            //act
            var result = _service.GetAsync(3);
            var author = result.Result;

            //assert
            Assert.True(author.Id == 3);
        }

        [Fact]
        public void Can_Get_Author_By_Id_Nonexistent()
        {
            //arrange
            Initialize();
            _authorRepositoryMock.Setup(r => r.GetById(3)).Returns(new Author { Id = 3, DateOfBirth = DateTime.Now, FirstName = "FN3", LastName = "LN3", Nationality = "Turc" });

            //act
            var result = _service.GetAsync(4);

            //assert
            Assert.True(result.Result == null);
        }

        [Fact]
        public void Can_Get_Authors_Blank_Repository()
        {
            //arrange
            Initialize();
            _authorRepositoryMock.Setup(r => r.GetAllEntities()).Returns(new List<Author>());
            
            //act
            var result = _service.GetAsync();
            var authors = result.Result.ToList();

            //assert
            Assert.True(authors.Count == 0);
            Assert.True(result.Exception == null);
        }
    }
}
