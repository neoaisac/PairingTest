using System;
using NUnit.Framework;
using PairingTest.Web.Middleware.Http;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    internal class HttpClientContainerTests
    {
        [Test]
        public void ActsAsFactory()
        {
            // Arrange
            var httpClientContainer = new HttpClientContainer();

            // Act
            var httpClient = httpClientContainer.Get(new Uri("http://google.com"));

            //Assert
            Assert.That(httpClient, Is.Not.Null);
        }

        [Test]
        public void OnlyGeneratesANewInstanceTheFirstTimePerUri()
        {
            // Arrange
            var httpClientContainer = new HttpClientContainer();

            // Act
            var httpClient1 = httpClientContainer.Get(new Uri("http://google.com"));
            var httpClient2 = httpClientContainer.Get(new Uri("http://google.com"));

            // Assert
            Assert.That(object.ReferenceEquals(httpClient1, httpClient2));
        }

        [Test]
        public void DifferentUrisGenerateDifferentClients()
        {
            // Arrange
            var httpClientContainer = new HttpClientContainer();

            // Act
            var httpClient1 = httpClientContainer.Get(new Uri("http://google.com"));
            var httpClient2 = httpClientContainer.Get(new Uri("http://microsoft.com"));

            // Assert
            Assert.That(!object.ReferenceEquals(httpClient1, httpClient2));
        }

        [Test]
        public void ReferencesAreKeptOnSuccessiveGenerations()
        {
            // Arrange
            var httpClientContainer = new HttpClientContainer();

            // Act
            var httpClient1 = httpClientContainer.Get(new Uri("http://google.com"));
            var httpClient2 = httpClientContainer.Get(new Uri("http://microsoft.com"));
            var httpClient3 = httpClientContainer.Get(new Uri("http://google.com"));
            var httpClient4 = httpClientContainer.Get(new Uri("http://microsoft.com"));

            // Assert
            Assert.That(object.ReferenceEquals(httpClient1, httpClient3));
            Assert.That(object.ReferenceEquals(httpClient2, httpClient4));
        }
    }
}