using CandidateFinder.Api.Controllers;
using CandidateFinder.MediatRService.CandidateService;
using CandidateFinder.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CandidateFinder.Test
{
    [TestFixture]
    public class CandidateControllerTest
    {
        private Mock<IMediator> _mediatoryMock;
        private CandidateFinderController _controller;

        [SetUp]
        public void Setup()
        {
            _mediatoryMock = new Mock<IMediator>();
            _controller = new CandidateFinderController(_mediatoryMock.Object);
        }

        [Test]
        public async Task UpsertCandidate_Success()
        {
            //Arrange

            var candidateDto = new CandidateDTO
            {
                Id = 1,
                FirstName = "Akash",
                LastName = "G C",
                Email = "testaemail@gmail.com",
                PhoneNumber = "986777777777",
                Comment = "This is test comment"
            };

            _mediatoryMock.Setup(m => m.Send(It.IsAny<UpsertCandidateCommand>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(new ResponseModel<CandidateDTO> { Result = candidateDto });

            //Act
            var result = await _controller.UpsertAsync(candidateDto) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var responseModel = result.Value.GetType().GetProperty("Result")?.GetValue(result.Value) as CandidateDTO;
            Assert.NotNull(responseModel);
            Assert.AreEqual(candidateDto.Email, responseModel.Email);
        }
        [Test]
        public async Task UpsertCandidate_Failure()
        {
            //Arrange
            var candidateDto = new CandidateDTO
            {
                Id = 1,
                FirstName = "Akash",
                LastName = "G C",
                Email = "",
                PhoneNumber = "986777777777",
                Comment = "This is test comment"
            };
            _controller.ModelState.AddModelError("Email", "Required");

            //Act
            var result = await _controller.UpsertAsync(candidateDto);

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var responseModel = result as BadRequestObjectResult;
            Assert.AreEqual("There is error in the request", responseModel.Value);
        }
    }
}