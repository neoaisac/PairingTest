using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Middleware.Http;
using PairingTest.Web.Models;
using QuestionServiceWebApi;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    internal class QuestionnaireControllerTests
    {
        private static class StubFactory
        {
            public static HttpResponseMessage GetHttpResponseMessage()
            {
                var result = new Questionnaire
                {
                    QuestionnaireTitle = "Test questionnaire title",
                    QuestionsText = new List<string>
                        {
                            "Question 1",
                            "Question 2"
                        }
                };

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json")
                };
            }

            public static IHttpClientContainer GetHttpClientContainer()
            {
                var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
                httpMessageHandlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                    .Returns(Task.FromResult(GetHttpResponseMessage()));

                var httpClientContainerMock = new Mock<IHttpClientContainer>();
                httpClientContainerMock.Setup(x => x.Get(It.IsAny<Uri>())).Returns(new HttpClient(httpMessageHandlerMock.Object));

                return httpClientContainerMock.Object;
            }
        }

        [Test]
        public void ViewModelGetsQuestionnaireTitleFromExternalService()
        {
            // Arrange
            var questionnaireController = new QuestionnaireController(StubFactory.GetHttpClientContainer());

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;

            // Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo("Test questionnaire title"));
        }

        public void ViewModelGetsQuestionsFromExternalService()
        {
            // Arrange
            var questionnaireController = new QuestionnaireController(StubFactory.GetHttpClientContainer());

            // Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;

            // Assert
            Assert.That(result.QuestionsText.Count, Is.EqualTo(2));
            Assert.That(result.QuestionsText[0], Is.EqualTo("Question 1"));
            Assert.That(result.QuestionsText[1], Is.EqualTo("Question 2"));
        }
    }
}