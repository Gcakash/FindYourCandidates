using CandidateFinder.Api.Controllers;
using CandidateFinder.Data.CandidateFinderDbContext;
using CandidateFinder.MediatRService.CandidateService;
using CandidateFinder.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CandidateFinder.Test.CandidateTest
{
    [TestFixture]
    public class CandidateserviceTest
    {
        private Mock<IMediator> _mediatoryMock;
        private CandidateFinderController _controller;
        private DbContextOptions<AppllicationDbContext> _options;
        private AppllicationDbContext _context;

        [SetUp]
        public void Setup()
        {
          _options = new DbContextOptionsBuilder<AppllicationDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;
            _context = new AppllicationDbContext(_options);
            _context.Database.OpenConnection();
            _context.Database.EnsureCreated();
        }
        [TearDown]
        public void TearDown()
        {
            _context.Database.CloseConnection();
            _context.DisposeAsync();
        }

        private async Task AddCandidateDataAsync()
        {
            var candidate = new Candidate
            {
                Id = 1,
                FirstName = "Akash",
                LastName = "G C",
                Email = "test1@gmail.com",
                PhoneNumber = "986777777777",
                Comment = "This is test comment",

            };

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
        }

        [Test]
        public async Task Insert_Candidate_Success()
        {
            //Arrange
            //await AddCandidateDataAsync();

            var newCandidate = new CandidateDTO {
                Id = 1,
                FirstName = "Jon",
                LastName = "G",
                Email = "test2@gmail.com",
                PhoneNumber = "986777777777",
                Comment = "This is test comment 2",
                PreferredCallTime = "www.com",
                GitHubUrl = "wwww.com",
                LinkedInUrl = "wwwww.com",
            };

            var command = new UpsertCandidateCommand(newCandidate);
            var handler = new UpsertCandidateCommandHandler(_context);
            //Act
            var result =  await handler.Handle(command,CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.IsNull(result.Error);
            var candidateInDb = await _context.Candidates.FirstOrDefaultAsync(c => c.Email == newCandidate.Email);
            Assert.IsNotNull(candidateInDb);
            Assert.AreEqual("Jon", candidateInDb.FirstName);
            Assert.AreEqual("986777777777", candidateInDb.PhoneNumber);
        }

        [Test]
        public async Task Update_Candidate_Success()
        {
            //Arrange
            var candidate = new Candidate
            {
                Id = 2,
                FirstName = "Akash",
                LastName = "G C",
                Email = "test1@gmail.com",
                PhoneNumber = "986777777777",
                Comment = "This is test comment",
                PreferredCallTime = "www.com",
                GitHubUrl = "wwww.com",
                LinkedInUrl = "wwwww.com",
            };

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            var updatedCandidate = new CandidateDTO
            {
                Id = 3,
                FirstName = "Mira",
                LastName = "G",
                Email = "test1@gmail.com",
                PhoneNumber = "986722222",
                Comment = "Updated data",
                PreferredCallTime = "www.com",
                GitHubUrl = "wwww.com",
                LinkedInUrl = "wwwww.com",
            };

            var command = new UpsertCandidateCommand(updatedCandidate);
            var handler = new UpsertCandidateCommandHandler(_context);
            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.IsNull(result.Error);
            var candidateInDb = await _context.Candidates.FirstOrDefaultAsync(c => c.Email == updatedCandidate.Email);
            Assert.IsNotNull(candidateInDb);
            Assert.AreEqual("Mira", candidateInDb.FirstName);
            Assert.AreEqual("986722222", candidateInDb.PhoneNumber);
        }

        [Test]
        public async Task MissngEmail_ReturnError()
        {
            //Arrange
            var candidate = new Candidate
            {
                Id = 1,
                FirstName = "Akash",
                LastName = "G C",
                Email = "test1@gmail.com",
                PhoneNumber = "986777777777",
                Comment = "This is test comment",
                PreferredCallTime = "www.com",
                GitHubUrl = "wwww.com",
                LinkedInUrl = "wwwww.com",
            };

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            var updatedCandidate = new CandidateDTO
            {
                Id = 1,
                FirstName = "Mira",
                LastName = "G",
                Email = "",
                PhoneNumber = "986722222",
                Comment = "Updated data",
                PreferredCallTime = "www.com",
                GitHubUrl = "wwww.com",
                LinkedInUrl = "wwwww.com",
            };

            var command = new UpsertCandidateCommand(updatedCandidate);
            var handler = new UpsertCandidateCommandHandler(_context);
            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Error);       
            Assert.AreEqual("Email is required", result.Error.ErrorMessage);
        }
    }
}