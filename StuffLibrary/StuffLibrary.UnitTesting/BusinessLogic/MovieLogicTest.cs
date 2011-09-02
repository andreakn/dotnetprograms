﻿using Moq;
using NUnit.Framework;
using StuffLibrary.Common.Logging;
using StuffLibrary.Domain;
using StuffLibrary.Lib.BusinessLogic;
using StuffLibrary.Repository;
using StuffLibrary.UnitTesting.Asserting;
using StuffLibrary.UnitTesting.Builders;
using StuffLibrary.UnitTesting.Faking;

namespace StuffLibrary.UnitTesting.BusinessLogic
{
    [TestFixture]
    public class MovieLogicTest
    {
        private MovieLogic _movieLogic;
        private Mock<IStuffLibraryRepo> _repoMock;
        private Mock<IStuffLibraryLogger> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IStuffLibraryRepo>();
            _loggerMock = new Mock<IStuffLibraryLogger>();
            _movieLogic = new MovieLogic(_repoMock.Object, _loggerMock.Object);
        }

        [Test]
        public void ShouldGetAllMovies()
        {
            var movie1 = Build.Movie().WithTitle(Some.Title).Item;
            var movie2 = Build.Movie().WithTitle(Some.OtherTitle).Item;
            var allMovies = new FakeQueryable<Movie>(movie1, movie2);
            _repoMock.Setup(repo => repo.GetAll<Movie>()).Returns(allMovies);
            var movies = _movieLogic.GetAllMovies("");
            CustomAssert.ThatCollection(movies)
                .HasCount(2)
                .Contains(movie1)
                .Contains(movie2);
        }

        [Test]
        public void Save_ShouldSaveNewMovie()
        {
            var movie = Build.NewMovie().WithTitle(Some.Title).Item;
            _movieLogic.Save(movie);
            _repoMock.Verify(repo => repo.Add(movie));
            _repoMock.Verify(repo => repo.SaveChanges());
        }

        [Test]
        public void Save_ShouldUpdateExistingMovie()
        {
            var existing = Build.Movie().WithTitle(Some.Title).Item;
            _repoMock.Setup(repo => repo.Get<Movie>(existing.Id)).Returns(existing);
            var updated = Build.NewMovie().WithId(existing.Id).WithTitle(Some.OtherTitle).Item;
            _movieLogic.Save(updated);
            _repoMock.Verify(repo => repo.Add(updated), Times.Never());
            _repoMock.Verify(repo => repo.SaveChanges());
        }
    }
}