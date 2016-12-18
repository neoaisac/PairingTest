using Moq;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Middleware.Http;
using PairingTest.Web.Models;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var httpClientContainerMock = new Mock<IHttpClientContainer>();
            var questionnaireController = new QuestionnaireController(httpClientContainerMock.Object);

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;

            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo("My expected questions"));
        }
    }
}