using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using PairingTest.Web.Middleware.Http;
using PairingTest.Web.Models;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IHttpClientContainer _httpClientContainer;

        public Uri QuestionnaireServiceUri { get; set; }

        public QuestionnaireController(IHttpClientContainer httpClientContainer)
        {
            _httpClientContainer = httpClientContainer;
        }

        public async Task<ViewResult> Index()
        {
            var viewModel = new QuestionnaireViewModel();

            var httpClient = _httpClientContainer.Get(QuestionnaireServiceUri);
            var httpResponse = await httpClient.GetAsync("Questions");
            if (!httpResponse.IsSuccessStatusCode)
                return View("Oops", new ErrorViewModel(HttpStatusCode.ServiceUnavailable, "An underlying service is now unavailable. Please try again later."));

            var content = await httpResponse.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(content);

            viewModel.QuestionnaireTitle = jObject["QuestionnaireTitle"].Value<string>();
            viewModel.QuestionsText = jObject["QuestionsText"].Values<string>().ToArray();

            return View(viewModel);
        }
    }
}